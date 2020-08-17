using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Service.Interface
{
    public interface IMyHubHelper
    {
        void SendData(ToDo.Entity.ToDo data);
    }
}
