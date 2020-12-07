using System;
/// <summary>
/// işin ne yaptıgını değil. işi tek bir yerden yapmamızı sağlar 
/// </summary>
namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
        }
    }

    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("loglandı");
        }
    }

    internal interface ILogging
    {
        void Log();
    }

    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("cachelendi ");
        }
    }

    internal interface ICaching
    {
        void Cache();
    }

    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("kullanıcı kontrol edildi");
        }
    }

    internal interface IAuthorize
    {
        void CheckUser();
    }

    class Validation : IValidation
    {
        public void Validate()
        {
            Console.WriteLine("validasyonlar");
        }
    }

    internal interface IValidation
    {
        void Validate();
    }

    class CustomerManager
    {
        CrossCuttingConcernsFacade _concerns;
        public CustomerManager()
        {
            _concerns = new CrossCuttingConcernsFacade();
        }

        public void Save()
        {
            _concerns.Logging.Log();
            _concerns.Caching.Cache();
            _concerns.Authorize.CheckUser();
            _concerns.Validation.Validate();
            Console.WriteLine("kaydedildi");
        }
    }

    class CrossCuttingConcernsFacade
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;
        public IValidation Validation;

        public CrossCuttingConcernsFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
            Validation = new Validation();
        }
    }
}
