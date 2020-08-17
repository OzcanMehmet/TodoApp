using System;
using System.Collections.Generic;
using ToDo.Entity;

namespace ToDo.Data.Interface
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        IEnumerable<T> GetAll();
        T FindById(int EntityId);
        void Insert(T Entity);
        void Update(T Entity);
        void Delete(T Entity);

    }
}
