using System;
using System.Collections.Generic;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            StockManager stockManager = new();
            BuyStock buyStock = new(stockManager);
            SellStock sellStock = new(stockManager);

            StockController stockController = new();
            stockController.TakeOrder(buyStock);
            stockController.TakeOrder(sellStock);
            stockController.TakeOrder(buyStock);
            stockController.PlaceOrders();

        }
    }
    class StockManager
    {
        string _productName = "Laptop";
        int _quantity = 10;

        public void Buy()
        {
            _quantity += 1;
            Console.WriteLine("Stock : {0} => {1} bought!", _productName, _quantity);
        }
        public void Sell()
        {
            _quantity -= 1;
            Console.WriteLine("Stock : {0} => {1} sold!", _productName, _quantity);
        }
    }
    interface IOrder
    {
        void Execute();
    }
    class BuyStock : IOrder
    {
        StockManager _stockManager;
        public BuyStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }
        public void Execute()
        {
            _stockManager.Buy();
        }
    }
    class SellStock : IOrder
    {
        StockManager _stockManager;
        public SellStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }
        public void Execute()
        {
            _stockManager.Sell();
        }
    }
    class StockController
    {
        List<IOrder> _orders = new();
        public void TakeOrder(IOrder order)
        {
            _orders.Add(order);
        }
        public void PlaceOrders()
        {
            foreach (var order in _orders)
            {
                order.Execute();
            }
            _orders.Clear();
        }
    }
}
