﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageBus bus = new MessageBus();
            Logic logic = new Logic();

            Action<Message> onReceive = logic.OnReceiveInRestService;

            onReceive += (Message m) => Console.WriteLine("ololololo");
            onReceive += (Message m) => Console.WriteLine("KWAKWAKWA 2-ka po C# !!!!");

            bus.PullMessageFromQueue("NormalQueue", onReceive);
        }
    }
}
