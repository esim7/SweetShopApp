using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Infrastructure.DataBase.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(int? id);

        IQueryable<T> GetAll();

        T Create(T entity);

        T Edit(T entity);

        void Remove(T entity);
    }
}