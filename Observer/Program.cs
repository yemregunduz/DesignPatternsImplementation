using System;
using System.Collections.Generic;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerObserver = new CustomerObserver();
            var employeeObserver = new EmployeeObserver();
            ProductManager productManager = new();
            productManager.Attach(customerObserver);
            productManager.Attach(employeeObserver);
            productManager.UpdatePrice();
            Console.WriteLine("-------AFTER DETACH CUSTOMER OBSERVER---------");
            productManager.Detach(customerObserver);
            productManager.UpdatePrice();
            Console.ReadLine();
        }
        class ProductManager
        {
            List<Observer> _observers = new List<Observer>();
            public void UpdatePrice()
            {
                Console.WriteLine("Product price updated.");
                Notify();
            }
            public void Attach(Observer observer)
            {
                _observers.Add(observer);
            }
            public void Detach(Observer observer)
            {
                _observers.Remove(observer);
            }
            private void Notify()
            {
                foreach (var observer in _observers)
                {
                    observer.Update();
                }
            }
        }
        abstract class Observer
        {
            public abstract void Update();
        }
        class CustomerObserver : Observer
        {
            public override void Update()
            {
                Console.WriteLine("Message to customer: Product price changed!");
            }
        }
        class EmployeeObserver : Observer
        {
            public override void Update()
            {
                Console.WriteLine("Message to employee: Product price changed!");
            }
        }
    }
}
