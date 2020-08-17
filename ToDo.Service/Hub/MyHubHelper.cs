using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using ToDo.Service.Interface;

namespace ToDo.Service
{
    public class MyHubHelper : IMyHubHelper
    {
        private readonly IHubContext<TodoHub> _hubContext;

        public MyHubHelper(IHubContext<TodoHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public void SendData(ToDo.Entity.ToDo data)
        {
            _hubContext.Clients.All.SendAsync("TodoExecute", JsonSerializer.Serialize(data));
        }
    }
}
