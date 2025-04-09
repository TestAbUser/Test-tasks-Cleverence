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
        private static readonly object _locker = new();
        public static int GetCount()
        {
            return count;
        }

        public static void AddToCount(int value)
        {
            lock (_locker)
            {
                count += value;
            }
            //count+=value;

        }
    }
}
