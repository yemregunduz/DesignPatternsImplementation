using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            AuthManager authManager = new AuthManager();
            authManager.Login();
            Console.ReadLine();
        }
       
        class AuthManager
        {
            private CrossCuttingConcernsFacade _concerns;

            public AuthManager()
            {
                _concerns = new CrossCuttingConcernsFacade(); 
            }
            public void Login()
            {
                _concerns.Authorize.CheckUser();
                _concerns.Caching.Cache();
                _concerns.Logging.Log();
                Console.WriteLine("Authorization Successful");
            }
        }
        class CrossCuttingConcernsFacade
        {
            public ILogging Logging;
            public ICaching Caching;
            public IAuthorize Authorize;

            public CrossCuttingConcernsFacade()
            {
                Logging = new Logging();
                Caching = new Caching();
                Authorize = new Authorize();
            }
        }
        interface ILogging
        {
            public void Log();
        }
        interface ICaching
        {
            public void Cache();
        }
        interface IAuthorize
        {
            public void CheckUser();
        }
        class Logging : ILogging
        {
            public void Log()
            {
                Console.WriteLine("Logged");
            }
        }
        class Caching : ICaching
        {
            public void Cache()
            {
                Console.WriteLine("Cached");
            }
        }
        class Authorize : IAuthorize
        {
            public void CheckUser()
            {
                Console.WriteLine("User Checked");
            }
        }
    }

   
}
