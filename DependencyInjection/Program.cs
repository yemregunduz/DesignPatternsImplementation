using Ninject;
using System;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            //kernel.Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
            kernel.Bind<IProductDal>().To<NhProductDal>().InSingletonScope();
            ProductManager productManager = new(kernel.Get<IProductDal>());
            productManager.Save();
        }
    }
    interface IProductDal
    {
        public void Save();
    }
    class EfProductDal:IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with Entity Framework");
        }
    }
    class NhProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with Nhibernate");
        }
    }
    class ProductManager
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Save()
        {
            //Business code 
            _productDal.Save();
        }
    }
}
