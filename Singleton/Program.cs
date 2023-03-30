using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager; // dış erişime engelle
        static object _lockedObject = new object(); //thread safe

        private CustomerManager()
        {

        }

        public static CustomerManager CreateAsSingleton()
        {
            //nesne örneğini aynı anda üretilmesinin önüne geçmek için bunu kullanıyoruz.
            lock (_lockedObject) 
            {
                //_customerManager ?? (_customerManager = new CustomerManager());
                _customerManager ??= new CustomerManager();
            }

            return _customerManager;
        }

        public void Save()
        {
            Console.WriteLine("kaydet");
        }
    }
}
