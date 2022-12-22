using System;

namespace SingletonPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Singleton instance = new Singleton();
            Singleton instance1 = Singleton.Instance;
            Singleton instance2 = Singleton.Instance;
            
            if (instance1 == instance2)
            {
                Console.WriteLine("Objects are the same instance");
            }

            Console.ReadKey();
        }
    }
}
