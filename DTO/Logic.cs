using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Logic
    {
        public Action<Message> OnReceiveInRestService =
            (Message message) =>
            {
                Console.WriteLine(message.ExchangeName);
                MessageBus bus = new MessageBus();

                Message m = new Message("DocumentQueue");
                bus.PushMessageToExchange(m);
            };

        public void OnReceiveInDocumentService(Message message)
        {
            File.AppendAllText(@"C:\Users\An\Desktop\output.txt", message.ExchangeName + Environment.NewLine);
            Console.WriteLine(message.ExchangeName);
        }
    }
}
