using System;

namespace Factory
{
    public class AdamGibiLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Adam gibi Loglandı"); 
        }
    }
}
