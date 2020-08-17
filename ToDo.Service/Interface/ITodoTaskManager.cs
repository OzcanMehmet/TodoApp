using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Data.Interface;

namespace ToDo.Service.Interface
{
    public interface ITodoTaskManager
    {
        void SetJob(Entity.ToDo Entity);
        void RemoveJob(Entity.ToDo Entity);
        void Update(Entity.ToDo Entity);

        void SetRepository(IToDoRepository TodoRepository);

     
    }
}
