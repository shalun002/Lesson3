using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageBus bus = new MessageBus();

            while (true)
            {
                bus.PushMessageToExchange(new Message("NormalQueue"));
                Thread.Sleep(5000);
            }
        }
    }
}
