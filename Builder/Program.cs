using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector productDirector = new ProductDirector();
            var builder = new NewCustomerProductBuilder();
            productDirector.GeneratedProduct(builder);

            var model = builder.GetModel();
            Console.WriteLine("Id " + model.Id);
            Console.WriteLine("CategoryName " + model.CategoryName);
            Console.WriteLine("ProductName " + model.ProductName);
            Console.WriteLine("DiscountApplied " + model.DiscountApplied);
            Console.WriteLine("DiscountedPrice " + model.DiscountedPrice);
            Console.WriteLine("UnitPrice " + model.UnitPrice);
            Console.ReadLine();
        }
    }

    class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }

    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();
    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice * (decimal)0.90;
            model.DiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "bilgisayar";
            model.ProductName = "asus";
            model.UnitPrice = 5000;
        }
    }

    class OldCustomerProductBuilder : ProductBuilder
    {

        ProductViewModel model = new ProductViewModel();
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice;
            model.DiscountApplied = false;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "bilgisayar";
            model.ProductName = "asus";
            model.UnitPrice = 5000;
        }
    }

    class ProductDirector
    {
        public void GeneratedProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}
