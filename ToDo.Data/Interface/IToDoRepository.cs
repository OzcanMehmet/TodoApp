using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Entity;

namespace ToDo.Data.Interface
{
    public interface IToDoRepository : IBaseRepository<Entity.ToDo>
    {
        IEnumerable<Entity.ToDo> GetAllActive();
    }
}
