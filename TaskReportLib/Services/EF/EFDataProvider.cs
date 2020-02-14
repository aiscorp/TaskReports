using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TaskReportLib.Data;
using TaskReportLib.Entityes;
using TaskReportLib.Services.Interfaces;

namespace TaskReportLib.Services.EF
{
    public abstract class EFDataProvider<T> : IDataProvider<T> where T : BaseEntity
    {
        protected readonly DataContextProvider _db;
        // -----
        protected EFDataProvider(DataContextProvider db) => _db = db;
        // -----
        public IEnumerable<T> GetAll()
        {
            using (var db = _db.CreateContext())
                return db.Set<T>().ToArray();
        }

        public T GetById(int id)
        {
            using (var db = _db.CreateContext())
                return db.Set<T>().FirstOrDefault(r => r.Id == id);
        }

        public int Create(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            using (var db = _db.CreateContext())
            {
                var table = db.Set<T>();
                if (table.Any(r => r.Id == item.Id))
                    return item.Id;

                table.Add(item);
                db.SaveChanges();

                return item.Id;
            }
        }

        public bool Remove(int id)
        {
            var db_item = GetById(id);
            using (var db = _db.CreateContext())
            {
                if (db_item is null) return false;
                db.Set<T>().Remove(db_item);
                db.SaveChanges();
                return true;
            }
        }

        public virtual void Edit(int id, T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            using (var db = _db.CreateContext())
            {
                if (!db.Set<T>().Any(s => s.Id == id)) return;
                
                var db_item = db.Set<T>()
                   .FirstOrDefault(s => s.Id == id)
                    ?? throw new InvalidOperationException($"Объект id:{id} не получен из базы данных, хотя должен находиться в ней");

                db_item = item;
                db.SaveChanges();
            }
        }
    }
}
