using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonalCar personalCar = new() { BrandName="Bmw",Model="5.20",HirePrice=2500};
            SpecialOffer specialOffer = new(personalCar) { DiscountRate = 10};
            Console.WriteLine("Concrete: " + personalCar.HirePrice);
            Console.WriteLine("Special Offer: "+specialOffer.HirePrice);
        }
    }
    abstract class CarBase
    {
        public abstract string BrandName { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }
    class PersonalCar : CarBase
    {
        public override string BrandName { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }
    abstract class CarDecoratorBase:CarBase
    {
        private CarBase _caseBase;

        protected CarDecoratorBase(CarBase caseBase)
        {
            _caseBase = caseBase;
        }
    }
    class SpecialOffer : CarDecoratorBase
    {
        public int DiscountRate { get; set; }
        private readonly CarBase _carBase;
        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }
        public override string BrandName { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get { return _carBase.HirePrice-_carBase.HirePrice*DiscountRate/100; } set { } }
    }
}
