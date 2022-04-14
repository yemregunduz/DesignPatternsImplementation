using System;
using System.Collections;
using System.Collections.Generic;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee yunusEmre = new () { Name="Yunus Emre Gündüz"};
            Employee fatmaNur = new () { Name = "Fatma Nur Karaman" };
            fatmaNur.AddSubordinate(yunusEmre);

            Employee fatihMehmet = new () { Name = "Fatih Mehmet Gündüz" };
            fatmaNur.AddSubordinate(fatihMehmet);

            Employee selimEge = new() { Name = "Selim Ege Çırpıcı" };
            yunusEmre.AddSubordinate(selimEge);

            Supplier aliCan = new() { Name = "Ali Can Çırpıcı" };
            fatihMehmet.AddSubordinate(aliCan);

            Console.WriteLine(fatmaNur.Name);
            foreach (Employee manager in fatmaNur)
            {
                Console.WriteLine("  -"+manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("    -"+employee.Name);
                }
            }
            Console.ReadLine();
        }
        interface IPerson
        {
             string Name { get; set; }
        }
        class Supplier : IPerson
        {
            public string Name { get; set;  }
        }
        class Employee : IPerson, IEnumerable<IPerson>
        {
            private List<IPerson> _subordinates = new List<IPerson>(); 
            public void AddSubordinate(IPerson person)
            {
                _subordinates.Add(person);
            }
            public void RemoveSubordinates(IPerson person)
            {
                _subordinates.Remove(person);
            }
            public IPerson GetSubOrdinate(int index)
            {
                return _subordinates[index];
            }
            public string Name { get; set; }

            public IEnumerator<IPerson> GetEnumerator()
            {
                foreach (var subordinate in _subordinates)
                {
                    yield return subordinate;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
