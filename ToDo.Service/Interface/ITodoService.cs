using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Service
{
    public interface ITodoService
    {
        IEnumerable<Entity.ToDo> GetAll();
        Entity.ToDo FindById(int EntityId);
        void Insert(Entity.ToDo Entity);
        void Update(Entity.ToDo Entity);
        void Delete(Entity.ToDo Entity);
    }
}
