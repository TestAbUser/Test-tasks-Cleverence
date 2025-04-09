namespace StaticServer
{
    public static class Server
    {
        public static int count;
        private static readonly object _locker = new object();
        public static int GetCount()
        {
            return count;
        }

        public static int AddToCount(int value)
        {
            count = value;
            return 0;
        }
    }


}


