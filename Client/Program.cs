using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                try
                {
                    var service =
                        (RemoteService)Activator.GetObject(typeof(RemoteService), "ipc://JimServerChannel/RemoteService");
                    Console.WriteLine("The remote object has been called {0} times", service.GetCount());

                    service.RaiseNotification("Hi, this is a client!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            catch (Exception)
            {
                Thread.Sleep(TimeSpan.FromSeconds(45));
                var service =
                    (RemoteService)Activator.GetObject(typeof(RemoteService), "ipc://JimServerChannel/RemoteService");
                Console.WriteLine("The remote object has been called {0} times", service.GetCount());

                service.RaiseNotification("There, this is a client!");
            }

            
            Console.ReadKey();
        }
    }
}
