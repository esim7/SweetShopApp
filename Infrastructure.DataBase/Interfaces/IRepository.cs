using System.Collections;
using System.Collections.Generic;

namespace Infrastructure.DataBase.Interfaces
{
    public interface IRepository<T> where T: class
    {
        bool Add(T entity);
        bool Edit(T entity);
        bool Delete(T entity);
        T Get(params object[] id);
        IList<T> GetAll();
        void Save();
    }
}