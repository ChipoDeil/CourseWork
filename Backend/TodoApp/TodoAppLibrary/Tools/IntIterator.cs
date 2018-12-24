namespace TodoAppLibrary.Tools
{
    public static class IntIterator
    {
        private static readonly object Obj = new object();
        private static int _id;

        public static int GetNextInt()
        {
            lock (Obj)
            {
                return ++_id;
            }
        }
    }
}