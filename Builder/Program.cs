using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector productDirector = new ProductDirector();
            var productBuilderForOldCustomer = new ProductBuilderForOldCustomer();
            var productBuilderForNewCustomer = new ProductBuilderForNewCustomer();
            productDirector.GenerateProduct(productBuilderForOldCustomer);
            productDirector.GenerateProduct(productBuilderForNewCustomer);

            var modelForOldCustomer = productBuilderForOldCustomer.GetModel();

            var modelForNewCustomer = productBuilderForNewCustomer.GetModel();

            Console.WriteLine($"Eski müşteriler {modelForOldCustomer.ProductName} için fiyatı: " + modelForOldCustomer.UnitPrice);
            Console.WriteLine("------------------");
            Console.WriteLine($"Yeni müşteriler {modelForNewCustomer.ProductName} için Fiyatı:" + modelForNewCustomer.UnitPrice);
        }
        class ProductViewModel
        {
            public int Id { get; set; }
            public string ProductName { get; set; }
            public decimal UnitPrice { get; set; }
            public int DiscountRate { get; set; }
            public bool DiscountApplied { get; set; }
        }
        abstract class ProductBuilder
        {
            public abstract void GetProductData();
            public abstract void ApplyDiscount();
            public abstract ProductViewModel GetModel();
        }
        class ProductBuilderForNewCustomer : ProductBuilder
        {
            ProductViewModel model = new ProductViewModel();
            public override void GetProductData()
            {
                model.Id = 1;
                model.ProductName = "Filtre Kahve";
                model.UnitPrice = 20;
            }
            public override void ApplyDiscount()
            {
                model.DiscountRate = 10;
                model.UnitPrice = model.UnitPrice-model.UnitPrice * model.DiscountRate / 100;
                model.DiscountApplied = true;

            }

            public override ProductViewModel GetModel()
            {
                return model;
            }
        }
        class ProductBuilderForOldCustomer : ProductBuilder
        {
            ProductViewModel model = new ProductViewModel();
            public override void GetProductData()
            {
                model.Id = 1;
                model.ProductName = "Filtre Kahve";
                model.UnitPrice = 20;
            }
            public override void ApplyDiscount()
            {
                model.DiscountApplied = false;
            }
            public override ProductViewModel GetModel()
            {
                return model;
            }
        }
        class ProductDirector
        {
            public void GenerateProduct(ProductBuilder productBuilder)
            {
                productBuilder.GetProductData();
                productBuilder.ApplyDiscount();
            }
        }
    }
}
