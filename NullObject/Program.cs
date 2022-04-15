using System;

namespace NullObject
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManagerTest customerManagerTest = new();
            customerManagerTest.SaveTest();
        }
    }
    class CustomerManager
    {
        private ILogger _logger;

        public CustomerManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Save()
        {
            Console.WriteLine("Saved");
            _logger.Log();
        }
    }
    interface ILogger
    {
        void Log();
    }
    class YegLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with YegLogger");
        }
    }
    class YtuLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with YtuLogger");
        }
    }
    class StubLogger : ILogger
    {
        private static StubLogger _stubLogger;
        private static object _lock = new object();
        private StubLogger()
        {

        }
        public static StubLogger GetInstance()
        {
            lock (_lock)
            {
                if (_stubLogger == null)
                {
                    _stubLogger = new StubLogger();
                }
            }
            return _stubLogger;
        }
        public void Log()
        {
        }
    }
    class CustomerManagerTest
    {
        public void SaveTest()
        {
            CustomerManager customerManager = new(StubLogger.GetInstance());
            customerManager.Save();
        }
    }

}
