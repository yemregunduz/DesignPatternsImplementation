using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManagerWithAdapterLogger = new ProductManager(new YtuLoggerAdapter());
            productManagerWithAdapterLogger.Save();
            Console.WriteLine("----------");
            ProductManager productManagerWithYegLogger = new ProductManager(new YegLogger());
            productManagerWithYegLogger.Save();
            Console.ReadLine();
        }
    }
    class ProductManager
    {
        ILogger _logger;

        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            _logger.Log("Product Data");
            Console.WriteLine("Saved");
        }
    }
    interface ILogger
    {
        void Log(string message);
    }
    class YegLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message+" Logged with YegLogger");
        }
    }
    //Nuget package
    class YtuLogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine(message + " Logged with YtuLogger");
        }
    }
    class YtuLoggerAdapter : ILogger
    {
        public void Log(string message)
        {
            YtuLogger logger = new YtuLogger();
            logger.LogMessage(message);
        }
    }
}
