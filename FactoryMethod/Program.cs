using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            customerManager.Save(LoggerType.YegLogger);
            Console.ReadLine();
        }
    }
    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger(LoggerType loggerType)
        {
            if (loggerType == LoggerType.YegLogger )
            {
                return new YegLogger();
            }
            else if(loggerType == LoggerType.YtuLogger)
            {
                return new YtuLogger();
            }
            return null;
        }
    }
    public interface ILoggerFactory
    {
        public ILogger CreateLogger(LoggerType loggerType);
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
        public void Save(LoggerType loggerType)
        {
            var logger = _loggerFactory.CreateLogger(loggerType);
            logger.Log();
        }
    }
    public enum LoggerType
    {
        YegLogger,
        YtuLogger
    }
}
