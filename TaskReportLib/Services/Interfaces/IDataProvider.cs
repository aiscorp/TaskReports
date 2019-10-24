using System.Collections.Generic;

namespace TaskReportLib.Services.Interfaces
{
    public interface IDataProvider<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        int Create(T item);
        void Edit(int id, T item);
        bool Remove(int id);
        void SaveChanges();
    }
}
