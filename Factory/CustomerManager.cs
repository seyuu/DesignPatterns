using System;

namespace Factory
{
    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("Kaydettik");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
