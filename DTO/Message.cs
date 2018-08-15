using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Message
    {
        public int Id { get; set; }
        public string ExchangeName { get; set; }
        public Message(string exchangeName)
        {
            ExchangeName = exchangeName;
        }
    }
}
