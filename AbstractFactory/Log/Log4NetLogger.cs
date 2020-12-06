using System;

namespace AbstractFactory
{
    public class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Log4net ile loglandı");
        }
    }
}
