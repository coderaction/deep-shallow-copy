using System;
using Copy.Models;

namespace ShallowCopy
{
     static class Program
    {
        static void Main(string[] args)
        {
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
            
            //Bazı durumlarda, elimizde ki modelinin kopyasını çıkartıp bazı alanları değiştirmek isteriz 
            //Genellikle nasıl yapıyoruz ? 
            
            var newProduct = new Products();
            newProduct.ProductName = "Silgi";
            newProduct.Discontinued = product.Discontinued;
            newProduct.Price = product.Price;
            newProduct.UnitInStock = newProduct.UnitInStock;
            newProduct.Categories = newProduct.Categories;
            newProduct.Orders = newProduct.Orders;
            //... bu şekilde devam ettiriyoruz. 
            
            //Sınıfın çok fazla özelliği olduğu durumlarda bu şekilde manuel yazmak hem efektif olmıcak, hem de sınıfa yeni eklenen bir property olması durumunda
            //bu sınıftan kopyalama yaptığımız her yerde güncelleme yapıyor olmamız gerekiyor. 
            
            //Veya başka türlü nasıl yaparız ? 

            var newProduct2 = product;
            
            //Peki yeni örneklediğimiz nesnede birşeyler değiştirmek istersek nasıl bir sonuç alırım ?

            newProduct2.ProductName = "Kalem Tıraş";
            
            //Bu şekilde yaparsak şöyle bir çıktı alıyoruz. 
            
            Console.WriteLine("");
            Console.WriteLine("--- Second Product ---");
            
            Console.WriteLine("Product Obje - Name: " + product.ProductName);
            Console.WriteLine("Product Obje - Discontinued: " + product.Discontinued);
            Console.WriteLine("Product Obje - Price: " + product.Price);
            Console.WriteLine("Product Obje - UnitInStock: " + product.UnitInStock);
            
            Console.WriteLine("");
            
            Console.WriteLine("Product Obje - Category- CategoryId: " + product.Categories.CategoryId);
            Console.WriteLine("Product Obje - Category -CategoryName: " + product.Categories.CategoryName);
            Console.WriteLine("Product Obje - Category- Description: " + product.Categories.Description);
            Console.WriteLine("Product Obje - Category- Picture: " + product.Categories.Picture);
            
           //Çıktıya bakıyoruz product.ProductName normalde "Kalem" olarak vermesi gerekirken, "Kalem Tıraş" çıktısı alıyoruz
           //2. product nesnesi olan newProduct2 'de değişikliklerin,1. product nesnemizde hiç bir değişiklik yapmamımıza rağmen
           //1. product nesneside değişiyor. 
           
           //Yukarıda ki gibi yaptığımızda da newProduct2.ProductName 'i değiştirdiğimde product objemde ki name alanıda "Kalemden",
           //"KalemTıraş" olarak değiştiğini görürsünüz
           
            //Tam da bunların önüne geçmek için Shallow Copy kullanıyoruz. 

            //Product model içine, sonradan ShollowCopy adı altında bir method ekliyorum ve aşağıda ki gibi olduğu modeli kopyalıyorum
            
            //Buraya kadar tamamsak
            //newProduct2.ProductName = "Kalem Tıraş"; 
            //Yukarıda ki kodumuzu yorum satırına çekelim =) 72. Satır
            
            //Aşağıda ki gibi kopyalayıp newProduct2.ProductName = "Kalem Tıraş" olarak değiştirip, product Nesnemin durumuna bakıyoruz

            newProduct2 = product.ShallowCopy();
            
            newProduct2.ProductName = "Kalem Tıraş";
            
            Console.WriteLine("");
            Console.WriteLine("--- ShallowCopy ---");
            
            Console.WriteLine("NewProduct2 Obje - Name: " + newProduct2.ProductName);
            Console.WriteLine("NewProduct2 Obje - Discontinued: " + newProduct2.Discontinued);
            Console.WriteLine("NewProduct2 Obje - Price: " + newProduct2.Price);
            Console.WriteLine("NewProduct2 Obje - UnitInStock: " + newProduct2.UnitInStock);
            
            Console.WriteLine("");
            
            Console.WriteLine("NewProduct2 Obje - Category- CategoryId: " + newProduct2.Categories.CategoryId);
            Console.WriteLine("NewProduct2 Obje - Category -CategoryName: " + newProduct2.Categories.CategoryName);
            Console.WriteLine("NewProduct2 Obje - Category- Description: " + newProduct2.Categories.Description);
            Console.WriteLine("NewProduct2 Obje - Category- Picture: " + newProduct2.Categories.Picture);
            
            Console.WriteLine("ShallowCopy 1. Product Nesnem ProductName: " + product.ProductName);
            
            // Görüldüğü üzere ShallowCopy kullandıktan sonra, 1. Product Nesnem aynı şekilde duruyor, 
            // 2. Product nesnemde de atadığım name alanı istediğim şekilde görüntüleniyor. 
            
            //Fakat Bu seneryoda, primitive tipler (string, int, bool) yeni değişkene kopyalamasını sağladık 
            //Peki ya obje tip alan tiplerin yada new olarak yaratılabilen nesnelerde durum nasıl? 
            
            //Şimdi Nesneleri değiştirmeye çalışalım Mesela Categori olanları
            
            
            newProduct2.Categories.CategoryId=2;
            newProduct2.Categories.CategoryName="Çanta";
            newProduct2.Categories.Description="Kategori Açıklama 2";
            newProduct2.Categories.Picture="123.jpg";
            
            Console.WriteLine("--- ShallowCopy Object Category 2 ---");

            Console.WriteLine("");
            
            Console.WriteLine("NewProduct2 Obje - Category- CategoryId: " + newProduct2.Categories.CategoryId);
            Console.WriteLine("NewProduct2 Obje - Category -CategoryName: " + newProduct2.Categories.CategoryName);
            Console.WriteLine("NewProduct2 Obje - Category- Description: " + newProduct2.Categories.Description);
            Console.WriteLine("NewProduct2 Obje - Category- Picture: " + newProduct2.Categories.Picture);
            
            Console.WriteLine("");
            
            Console.WriteLine("--- ShallowCopy Object Category 1 ---");
            
            Console.WriteLine("");
            
            Console.WriteLine("Product Obje - Category- CategoryId: " + product.Categories.CategoryId);
            Console.WriteLine("Product Obje - Category -CategoryName: " + product.Categories.CategoryName);
            Console.WriteLine("Product Obje - Category- Description: " + product.Categories.Description);
            Console.WriteLine("Product Obje - Category- Picture: " + product.Categories.Picture);

            //Çıktıya baktığımızda, newProduct2.Category' de değişiklik yaptık ama yaptığımız değişiklikler 1.product.category objeme de yansımış,
         
            //primitive tipler haricinde obje nesnelerini ShollowCopy kopyalayamıyor. 
            
            //Bu yüzden DeepCopy Kullanıyoruz. 
            
            //Elimizde ki değişkenin tamamen baştan kopyasını çıkartmak için DeepCopy Kullanıyoruz. 
        }
    }
}