using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var serverChannel = new IpcChannel("JimServerChannel");
            ChannelServices.RegisterChannel(serverChannel, false);

            var service = new RemoteService();
            service.Notify += s => Console.WriteLine($"Message from client received: {s}");

            RemotingServices.Marshal(service, "RemoteService", typeof(RemoteService));

            Console.WriteLine("Server running...");
            Console.ReadKey();
        }
    }
}
