using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactoryDB());
            customerManager.Save();
            Console.ReadLine();
        }
    }

    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new AdamGibiLogger();
        }
    }

    public class LoggerFactoryDB : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new InsanGibiLogger();
        }
    }
}
