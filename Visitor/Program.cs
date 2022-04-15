using System;
using System.Collections.Generic;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager fatmaNur = new() { Name = "Fatma Nur Karaman", Salary = 17000 };
            Manager yunusEmre = new() { Name="Yunus Emre Gündüz",Salary =15000};

            Worker fatihMehmet = new() { Name = "Fatih Mehmet Gündüz", Salary = 5000 };
            Worker selimEge = new() { Name = "Selim Ege Çıkrıkçı", Salary = 6750 };

            fatmaNur.Subordinates.Add(yunusEmre);
            yunusEmre.Subordinates.Add(fatihMehmet);
            yunusEmre.Subordinates.Add(selimEge);

            OrganisationalStructure organisationalStructure = new(fatmaNur);
            PayrollVisitor payrollVisitor = new();
            PayriseVisitor payriseVisitor = new();

            organisationalStructure.Accept(payrollVisitor);
            organisationalStructure.Accept(payriseVisitor);
        }
    }
    class OrganisationalStructure
    {
        public EmployeeBase Employee;
        public OrganisationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }
        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }
    abstract class EmployeeBase
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public abstract void Accept(VisitorBase visitor);
    }
    class Manager : EmployeeBase
    {
        public Manager()
        {
            Subordinates = new();
        }
        public List<EmployeeBase> Subordinates { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
            foreach (var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }
    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }
    abstract class VisitorBase
    {
        public abstract void Visit(Manager manager);
        public abstract void Visit(Worker worker);
    }
    class PayrollVisitor : VisitorBase
    {
        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1}",manager.Name,manager.Salary);
        }

        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}", worker.Name, worker.Salary);
        }
    }
    class PayriseVisitor : VisitorBase
    {
        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary increased to: {1}", manager.Name, manager.Salary*(decimal)1.1);
        }

        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary increased to: {1}", worker.Name, worker.Salary * (decimal)1.4);
        }
    }
}
