using System;
using System.Runtime;
using Copy.Models;

namespace DeepCopy
{
    static class Program
    {
        static void Main(string[] args)
        {
            //DeepCopy 'e başlamadan önce bir nesne üretelim ve içlerini dolduralım

            var product = new Products();
            product.ProductName = "Kalem";
            product.Discontinued = false;
            product.Price = 100;
            product.UnitInStock = 5;

            var category = new Categories
            {
                CategoryId = 1,
                Description = "Kategori Açıklaması",
                CategoryName = "Kırtasiye",
                Picture = "abc.img"
            };

            var order = new Orders()
            {
                Id = 1,
                Discount = 3,
                Quantity = 1,
                UnitPrice = 5
            };

            product.Categories = category;
            product.Orders = order;
            
            //Class'ı ekrana yazdıralım 
            
            Console.WriteLine("--- First Product ---");
            
            Console.WriteLine("Product Obje - Name: " + product.ProductName);
            Console.WriteLine("Product Obje - Discontinued: " + product.Discontinued);
            Console.WriteLine("Product Obje - Price: " + product.Price);
            Console.WriteLine("Product Obje - UnitInStock: " + product.UnitInStock);
            
            Console.WriteLine("Product Obje - Category- CategoryId: " + product.Categories.CategoryId);
            Console.WriteLine("Product Obje - Category -CategoryName: " + product.Categories.CategoryName);
            Console.WriteLine("Product Obje - Category- Description: " + product.Categories.Description);
            Console.WriteLine("Product Obje - Category- Picture: " + product.Categories.Picture);
            
            //DeepCopy'de ki senaryomuz şu shallowCopy'de ki senaryomuzla aynı olsun. 
            //Ben öncelikle gidip nesnemin bir kopyasını oluşturayım
            //Oluşturduğum kopyada bir primitive type olmayan bir nesnede değişiklik yapayım örn: Category
            //Bakalım, kopyalamayı yapan product nesnesinde bir değişiklik oluyor mu ? 
            
            //DeepCopy yapmak için Product Class'ımın içerisine gidip DeepCopy adında bir method ekliyorum. 
            //newProduct adında yeni bir nesne oluşturdum ve product nesnesinin birebire kopyasını istedim. 
            
            
            var newProduct = product.DeepCopy();

            newProduct.Categories.CategoryName = "Kitap";
            
            //Class'ları tekrar yazdıralım
            
            Console.WriteLine("--- First Product ---");
            
            Console.WriteLine("Product Obje - Name: " + product.ProductName);
            Console.WriteLine("Product Obje - Discontinued: " + product.Discontinued);
            Console.WriteLine("Product Obje - Price: " + product.Price);
            Console.WriteLine("Product Obje - UnitInStock: " + product.UnitInStock);
            
            Console.WriteLine("Product Obje - Category- CategoryId: " + product.Categories.CategoryId);
            Console.WriteLine("Product Obje - Category -CategoryName: " + product.Categories.CategoryName);
            Console.WriteLine("Product Obje - Category- Description: " + product.Categories.Description);
            Console.WriteLine("Product Obje - Category- Picture: " + product.Categories.Picture);
            
            Console.WriteLine("");
            
            Console.WriteLine("--- Secount Product ---");
            
            Console.WriteLine("Product Obje - Name: " + newProduct.ProductName);
            Console.WriteLine("Product Obje - Discontinued: " + newProduct.Discontinued);
            Console.WriteLine("Product Obje - Price: " + newProduct.Price);
            Console.WriteLine("Product Obje - UnitInStock: " + newProduct.UnitInStock);
            
            Console.WriteLine("Product Obje - Category- CategoryId: " + newProduct.Categories.CategoryId);
            Console.WriteLine("Product Obje - Category -CategoryName: " + newProduct.Categories.CategoryName);
            Console.WriteLine("Product Obje - Category- Description: " + newProduct.Categories.Description);
            Console.WriteLine("Product Obje - Category- Picture: " + newProduct.Categories.Picture);
        }
    }
}