using System;
/// <summary>
/// farklı sistemlerin kendi sistemlerimize entegre edilmesi durumunda, kendi sistemimizin bozulmadan, farklı olan sistemin sanki bizim sistemimizmiş gibi davranmasını sağlamaktır.
/// dışarda ki bir servisi kendi projemize dahil etmek istediğimizde kullanabiliriz. 
/// </summary>
namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Log4NetAdapter());
            productManager.Save();
            Console.ReadLine();
        }
    }

    class ProductManager
    {
        private ILogger _logger;

        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            _logger.Log("kaydedilen data");

            Console.WriteLine("kaydet");
        }
    }

    interface ILogger
    {
        void Log(string message);
    }

    class AnaLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("loglandı, {0}",message);
        }
    }

    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("log4net ile loglandı, {0}", message);
        }
    }

    class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage("heleloy");
        }
    }
}
