using System.Collections;
using System.Collections.Generic;

namespace Infrastructure.DataBase.Interfaces
{
    public interface IRepository<T> where T: class
    {
        IList<T> GetAll();
    }
}