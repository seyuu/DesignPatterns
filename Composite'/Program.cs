using System;
using System.Collections.Generic;

namespace Composite2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Root oluşturulur.   
            CompositePerson baskan = new CompositePerson("ali", Rank.baskan);


            // root altına Leaf tipten nesne örnekleri eklenir.
            baskan.AddPerson(new PrimitivePerson("emre1", Rank.yonetici));
            baskan.AddPerson(new PrimitivePerson("erol1", Rank.hoca));


            // Composite tipler oluşturulur.
            CompositePerson yonetici = new CompositePerson("emre", Rank.yonetici);
            CompositePerson hoca = new CompositePerson("erol", Rank.hoca);
            CompositePerson yardimci = new CompositePerson("volkan", Rank.yardimcihoca);
            CompositePerson futbolcu = new CompositePerson("altay", Rank.futbolcu);


            // Composite tipe bağlı primitive tipler oluşturulur.
            hoca.AddPerson(new PrimitivePerson("marco", Rank.yardimcihoca));
            yonetici.AddPerson(hoca);
            hoca.AddPerson(yardimci);
            futbolcu.AddPerson(new PrimitivePerson("mert", Rank.futbolcu));
            futbolcu.AddPerson(new PrimitivePerson("ozan", Rank.futbolcu));
            futbolcu.AddPerson(new PrimitivePerson("lemos", Rank.futbolcu));
            yardimci.AddPerson(futbolcu);
            // Root' un altına Composite nesne örneği eklenir.
            baskan.AddPerson(futbolcu);


            baskan.AddPerson(new PrimitivePerson("Zulu", Rank.futbolcu));


            // root için ExecuteOrder operasyonu uygulanır. Buna göre root altındaki tüm nesneler için bu operasyon uygulanır
           // baskan.ExecuteOrder();
            //yonetici.ExecuteOrder();
           // hoca.ExecuteOrder();
            yardimci.ExecuteOrder();

            Console.ReadLine();
        }
    }

    enum Rank
    {
        baskan,
        yonetici,
        hoca,
        yardimcihoca,
        futbolcu
    }

    /// Component sınıfı
    abstract class Person
    {

        protected string _name;
        protected Rank _rank;

        public Person(string name, Rank rank)
        {
            _name = name;
            _rank = rank;
        }

        public abstract void AddPerson(Person person);
        public abstract void RemovePerson(Person person);
        public abstract void ExecuteOrder(); // Hem Leaf hemde Composite tipi için uygulanacak olan fonksiyon
    }

    /// Leaf class
    class PrimitivePerson : Person
    {
        public PrimitivePerson(string name, Rank rank) : base(name, rank)
        {

        }

        // Bu fonksiyonun Leaf için anlamı yoktur.
        public override void AddPerson(Person person)
        {
            throw new NotImplementedException();
        }

        // Bu fonksiyonun Leaf için anlamı yoktur.
        public override void RemovePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public override void ExecuteOrder()
        {
            Console.WriteLine(String.Format("{0} {1}", _rank, _name));
        }

    }

    /// Composite Class
    class CompositePerson : Person
    {
        // Composite tip kendi içerisinde birden fazla Component tipi içerebilir. Bu tipleri bir koleksiyon içerisinde tutabilir.
        private List<Person> _Persons = new List<Person>();

        public CompositePerson(string name, Rank rank) : base(name, rank)
        {

        }

        // Composite tipin altına bir Component eklemek için kullanılır
        public override void AddPerson(Person person)
        {
            _Persons.Add(person);
        }

        // Composite tipin altındaki koleksiyon içerisinden bir Component tipinin çıkartmak için kullanılır
        public override void RemovePerson(Person person)
        {
            _Persons.Remove(person);
        }

        // Önemli nokta. Composite tip içerisindeki bu operasyon, Composite tipe bağlı tüm Component'ler için gerçekleştirilir.
        public override void ExecuteOrder()
        {
            Console.WriteLine(String.Format("{0} {1}", _rank, _name));

            foreach (Person person in _Persons)
            {
                person.ExecuteOrder();
            }
        }
    }
}
