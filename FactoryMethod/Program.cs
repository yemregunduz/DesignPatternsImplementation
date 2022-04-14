using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            customerManager.Save();
            Console.ReadLine();
        }
    }
    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new YegLogger();
        }
    }
    public interface ILoggerFactory
    {
        public ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }
    public class YegLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with YegLogger");
        }
    }
    public class YtuLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with YtuLogger");
        }
    }
    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void Save()
        {
            var logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
