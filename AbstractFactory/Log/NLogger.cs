using System;

namespace AbstractFactory
{
    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("NLogger ile loglandı");
        }
    }
}
