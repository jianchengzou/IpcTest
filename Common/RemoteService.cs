using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class RemoteService:MarshalByRefObject
    {
        public event Action<string> Notify;
        private int _callCount;

        public int GetCount()
        {
            Console.WriteLine("GetCount() has been called");
            _callCount++;
            return _callCount;
        }

        public void RaiseNotification(string message)
        {
            Notify?.Invoke(message);
        }
    }
}
