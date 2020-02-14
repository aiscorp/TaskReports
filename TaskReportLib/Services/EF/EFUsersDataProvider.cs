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

        public User GetUserAllById(int id)
        {
            using (var db = _db.CreateContext())  
            return db.Set<User>()
                    .Include("Jobs")
                    .Include("Tags")
                    .Include("Projects")
                    .FirstOrDefault(r => r.Id == id);
        }

        // Поиск юзера по имени, возвращает юзера или null при отсутствии в базе
        public User TryFindUserByName(string name)
        {
            using (var db = _db.CreateContext())
                return db.Set<User>().FirstOrDefault(r => r.UserName == name);
        }

    }
}
