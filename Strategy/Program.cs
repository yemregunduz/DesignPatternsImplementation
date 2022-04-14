using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new();
            customerManager.CreditCalculatorBase = new PersonalFinanceCredit();
            customerManager.SaveCredit();

            Console.WriteLine("-----------");

            customerManager.CreditCalculatorBase = new TransportCredit();
            customerManager.SaveCredit();
        }
    }
    abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }
    class PersonalFinanceCredit : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Personal finance credit calculated");
        }
    }
    class TransportCredit : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Transport credit calculated");
        }
    }
    class CustomerManager
    {
        public CreditCalculatorBase CreditCalculatorBase { get; set; }
        public void SaveCredit()
        {
            //Business code..
            CreditCalculatorBase.Calculate();

        }
    }
}
