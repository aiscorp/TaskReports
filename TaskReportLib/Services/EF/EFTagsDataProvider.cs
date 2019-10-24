using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskReportLib.Entityes;
using TaskReportLib.Services.Interfaces;

namespace TaskReportLib.Services.EF
{
    public class EFTagsDataProvider : EFDataProvider<Tag>, ITagsDataProvider
    {
        public EFTagsDataProvider(DataContextProvider db) : base(db) { }

        public override void Edit(int id, Tag item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            using (var db = _db.CreateContext())
            {
                if (!db.Tags.Any(s => s.Id == id)) return;

                //var db_item = GetById(id);
                //db.Senders.Attach(db_item);
                var db_item = db.Tags
                   .FirstOrDefault(s => s.Id == id)
                    ?? throw new InvalidOperationException($"Объект id:{id} не получен из базы данных, хотя должен находиться в ней");

                db_item.Name = item.Name;
                db_item.Text = item.Text;
                db_item.User = item.User;
                db_item.Color = item.Color;
                db.SaveChanges();
            }
        }
    }
}