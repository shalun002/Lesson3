using DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace DOC
{
    static class ConfigureService
    {
        internal static void Configure()
        {
            HostFactory.Run(configure =>
            {
                configure.Service<DocService>(service =>
                {
                    service.ConstructUsing(s => new DocService());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });

                configure.RunAs(@"ITSTEP\An", "1");
                configure.SetServiceName("DocumentProcessService");
                configure.SetDisplayName("DocumentProcessService");
                configure.SetDescription("DocumentProcessService");
            });
        }
    }

    public class DocService
    {
        public void Start()
        {
            try
            {
                MessageBus bus = new MessageBus();
                Logic logic = new Logic();

                Action<Message> onReceive = logic.OnReceiveInDocumentService;

                bus.PullMessageFromQueue("DocumentQueue", onReceive);
            }
            catch(Exception ex)
            {
                /*
                using (EventLog eventLog = new EventLog("TopShelf"))
                {
                    eventLog.Source = "TopShelf";
                    eventLog.WriteEntry("Exception on service", EventLogEntryType.Information, 101, 1);
                }*/
            }
        }

        public void Stop()
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureService.Configure();
        }
    }
}
