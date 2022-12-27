namespace SingletonPattern
{
    public class Singleton
    {
        // Using static property and private constructor 
        private static Singleton _instance;
        private static readonly object _lockObject = new();
        private Singleton()
        {
        }
        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new Singleton();

                        }
                    }
                }
                return _instance;
            }
        }
    }
}
