using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer { Id = 1, FirstName = "Yunus Emre", LastName = "Gündüz", City = "Sakarya" };

            Customer cloneCustomer = (Customer)customer.Clone();
            cloneCustomer.FirstName = "Fatih Mehmet";
            Console.WriteLine(customer.FirstName);
            Console.WriteLine("---------------");
            Console.WriteLine(cloneCustomer.FirstName);
            Console.ReadLine();
        }
    }
    public abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class Customer : Person
    {
        public string City { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
    public class Employee : Person
    {
        public decimal Salary { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
        
    }
}
