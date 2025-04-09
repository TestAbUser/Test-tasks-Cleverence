using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticServer
{
    public static class Server
    {
        private static int count;
        private static readonly object _locker = new object();
        public static int GetCount()
        {
            return count;
        }

        public static int AddToCount(int value)
        {
            lock (_locker)
            {
                count = value;
            }

            return count;
        }
    }
}
