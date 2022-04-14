using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManagerWithYegFactory = new (new YegFactory());
            customerManagerWithYegFactory.GetAll();
            Console.WriteLine("------------------------------");
            CustomerManager customerManagerWithYtuFactory = new (new YtuFactory());
            customerManagerWithYtuFactory.GetAll();
            Console.ReadLine();
        }
        public abstract class CrossCuttingConcernsFactory
        {
            public abstract Logging CreateLogger();
            public abstract Caching CreateChaching();
        }
        public class YtuFactory : CrossCuttingConcernsFactory
        {
            public override Caching CreateChaching()
            {
                return new YtuCache();
            }

            public override Logging CreateLogger()
            {
                return new YtuLogger();
            }
        }
        public class YegFactory : CrossCuttingConcernsFactory
        {
            public override Caching CreateChaching()
            {
                return new YegCache();
            }

            public override Logging CreateLogger()
            {
                return new YegLogger();
            }
        }
        public abstract class Logging
        {
            public abstract void Log(string message);
        }
        public class YegLogger : Logging
        {
            public override void Log(string message)
            {
                Console.WriteLine("Logged with YegLogger: " + message );
            }
        }
        public class YtuLogger : Logging
        {
            public override void Log(string message)
            {
                Console.WriteLine("Logged with YtuLogger: " + message);
            }
        }
        public abstract class Caching
        {
            public abstract void Cache(string data);
        }
        public class YtuCache : Caching
        {
            public override void Cache(string data)
            {
                Console.WriteLine("Cached with YtuCache: "+data);
            }
        }
        public class YegCache : Caching
        {
            public override void Cache(string data)
            {
                Console.WriteLine("Cached with YegCache: "+data);
            }
        }
        public class CustomerManager
        {
            CrossCuttingConcernsFactory _crossCuttingConcernsFactory;
            Logging _logging;
            Caching _caching;

            public CustomerManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
            {
                _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
                _logging = _crossCuttingConcernsFactory.CreateLogger();
                _caching = _crossCuttingConcernsFactory.CreateChaching();
            }

            public void GetAll()
            {
                _logging.Log("Message");
                _caching.Cache("Data");
                Console.WriteLine("Customer listed");
            }
        }
    }
}
