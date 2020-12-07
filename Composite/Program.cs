using System;
using System.Collections;
using System.Collections.Generic;

namespace Composite2
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee ali = new Employee { Name = "ali", Surname = "koç" };
            Employee emre = new Employee { Name = "emre", Surname = "belözoğlu" };
            Employee erol = new Employee { Name = "erol", Surname = "bulut" };
            Employee volkan = new Employee { Name = "volkan", Surname = "demirel" };
            Employee altay = new Employee { Name = "altay", Surname = "bayındır" };
            Contractor yardımcıhoca = new Contractor { Name = "marco", Surname = "aurelio" };

            ali.AddSubOrdinate(emre);
            ali.AddSubOrdinate(erol);
            erol.AddSubOrdinate(volkan);
            volkan.AddSubOrdinate(altay);
            erol.AddSubOrdinate(yardımcıhoca);

            Console.WriteLine(ali.Name + " " + ali.Surname);
            foreach (Employee baskan in ali)
            {
                Console.WriteLine($"  {baskan.Name + " " + baskan.Surname}");
                foreach (IPerson yonetici in baskan)
                {
                    Console.WriteLine($"    {yonetici.Name + " " + yonetici.Surname}");
                }
            }

            Console.ReadLine();
        }
    }

    interface IPerson
    {
        string Name { get; set; }
        string Surname { get; set; }
    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subOrdinates = new List<IPerson>();

        public void AddSubOrdinate(IPerson person)
        {
            _subOrdinates.Add(person);
        }

        public void RemoveSubOrdinate(IPerson person)
        {
            _subOrdinates.Remove(person);
        }

        public IPerson GetSubOrdinate(int index)
        {
            return _subOrdinates[index];
        }

        public string Name { get; set; }
        public string Surname { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var item in _subOrdinates)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
