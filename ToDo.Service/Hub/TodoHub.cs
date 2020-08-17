using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using ToDo.Service.Interface;

namespace ToDo.Service
{

    public class TodoHub : Hub
    {

        public override Task OnConnectedAsync()
        {
            System.Console.WriteLine("Yeni bir bağlantı: " + Context.ConnectionId);
          
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            System.Console.WriteLine("bağlantı kapandı: " + Context.ConnectionId);
         
            return base.OnDisconnectedAsync(exception);
        }
  

    }


}
