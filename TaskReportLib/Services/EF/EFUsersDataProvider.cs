using System;
using System.Collections.Generic;
using System.Linq;
using TaskReportLib.Entityes;
using TaskReportLib.Services.Interfaces;

namespace TaskReportLib.Services.EF
{
    public class EFUsersDataProvider : EFDataProvider<User>, IUsersDataProvider
    {
        public EFUsersDataProvider(DataContextProvider db) : base(db) { }

        public override void Edit(int id, User item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            using (var db = _db.CreateContext())
            {
                if (!db.Users.Any(s => s.Id == id)) return;
                                
                var db_item = db.Users
                   .FirstOrDefault(s => s.Id == id)
                    ?? throw new InvalidOperationException($"Объект id:{id} не получен из базы данных, хотя должен находиться в ней");

                db_item = item;

                //db_item.UserName = item.UserName;
                //db_item.PasswordHash = item.PasswordHash;
                //db_item.LastLogin = item.LastLogin;
                //db_item.MonthSpan = item.MonthSpan;
                //db_item.WeekSpan = item.WeekSpan;
                //db_item.YearSpan = item.YearSpan;
                db.SaveChanges();
            }
        }
    }
}
