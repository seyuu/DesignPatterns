using System;

namespace Factory
{
    public class InsanGibiLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("İnsan gibi Loglandı");
        }
    }
}
