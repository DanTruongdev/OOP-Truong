using lesson1.DAO;
using lesson1.Demo;
using lesson1.MuckEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Demo
{
    public class DatabaseDemo
    {
        private readonly Database _db;
        public DatabaseDemo()
        {
            _db = Database.Instance;
        }

        public void InsertTableTest()
        {
            Category categoryTest1 = new Category(11, "Adding Category Test1");
            Category categoryTest2 = new Category(12, "Adding Category Test2");
            _db.InsertTable("category", categoryTest1);
            _db.InsertTable("category", categoryTest2);
            PrintTableTest();
        }

        public void SelectTableTest()
        {
            var arr = _db.SelectTable("category", c => c.Id > 6);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"arr[{i}] = {arr[i]}");
            }
            Console.WriteLine();
        }

        //before update
        //public void UpdateTableTest()
        //{
        //    Product updateProduct = new Product(9, "Spectre x360 updated", "HP", 1199.99, 4);
        //    Console.WriteLine(_db.UpdateTable("product", updateProduct));
        //    PrintTableTest();
        //}

        //after update
        public void UpdateTableTest()
        {
            Product updateProduct = new Product(101, "Spectre x360 updated", "HP", 1199.99, 4);
            Console.WriteLine(_db.UpdateTableById(9, updateProduct));
            PrintTableTest();
        }

        public void DeleteTableTest()
        {
            Accessory deleteAccessory = new Accessory(5, "Laptop Stand");
            Console.WriteLine(_db.DeleteTable("accessory", deleteAccessory));
            PrintTableTest();
        }

        public void TruncateTable()
        {
            _db.TruncateTable("category");
            PrintTableTest();
        }
        
        public void InitDatabase()
        {
            Product[] productMockData = new Product[]
            {
                new Product(1, "MacBook Air M1", "Apple", 999.99, 5),
                new Product(2, "Surface Pro 7", "Microsoft", 799.99, 3),
                new Product(3, "XPS 13", "Dell", 899.99, 4),
                new Product(4, "ThinkPad X1 Carbon", "Lenovo", 1299.99, 2),
                new Product(5, "Pixelbook Go", "Google", 649.99, 6),
                new Product(6, "Galaxy Book S", "Samsung", 999.99, 3),
                new Product(7, "ROG Zephyrus G14", "Asus", 1449.99, 1),
                new Product(8, "Yoga C940", "Lenovo", 1099.99, 2),
                new Product(9, "Spectre x360", "HP", 1199.99, 4),
                new Product(10, "Inspiron 15", "Dell", 499.99, 7)
            };
           

            Category[] categoryMockData = new Category[]
            {
                new Category(1, "Laptops"),
                new Category(2, "Smartphones"),
                new Category(3, "Tablets"),
                new Category(4, "Desktops"),
                new Category(5, "Monitors"),
                new Category(6, "Printers"),
                new Category(7, "Cameras"),
                new Category(8, "Accessories"),
                new Category(9, "Networking"),
                new Category(10, "Software")
            };

            Accessory[] accessoryMockData = new Accessory[]
            {
                new Accessory(1, "Wireless Mouse"),
                new Accessory(2, "Mechanical Keyboard"),
                new Accessory(3, "USB-C Hub"),
                new Accessory(4, "External Hard Drive"),
                new Accessory(5, "Laptop Stand"),
                new Accessory(6, "Portable Charger"),
                new Accessory(7, "Bluetooth Speaker"),
                new Accessory(8, "Noise Cancelling Headphones"),
                new Accessory(9, "Webcam"),
                new Accessory(10, "Gaming Mouse Pad")
            };

            Array.ForEach(productMockData, mockData =>
            {
                _db.InsertTable("product", mockData);
            });

            Array.ForEach(categoryMockData, mockData =>
            {
                _db.InsertTable("category", mockData);
            });

            Array.ForEach(accessoryMockData, mockData =>
            {
                _db.InsertTable("accessory", mockData);
            });

            //PrintTableTest();
        }

        public void PrintTableTest()
        {
            Console.WriteLine("Product array:");
            var productArr = _db.SelectTable("product", p => p.Id > int.MinValue);
            for (int i = 0; i < productArr.Length; i++)
            {
                if (productArr[i] == null) break;
                Console.WriteLine($"arr[{i}] = {productArr[i]}");
            }
            Console.WriteLine();

            Console.WriteLine("Category array:");
            var categoryArr = _db.SelectTable("category", p => p.Id > int.MinValue);
            for (int i = 0; i < categoryArr.Length; i++)
            {
                if (categoryArr[i] == null) break;
                Console.WriteLine($"arr[{i}] = {categoryArr[i]}");
            }
            Console.WriteLine();

            Console.WriteLine("Accessory array:");
            var accessoryArr = _db.SelectTable("accessory", p => p.Id > int.MinValue);
            for (int i = 0; i < accessoryArr.Length; i++)
            {
                if (accessoryArr[i] == null) break;
                Console.WriteLine($"arr[{i}] = {accessoryArr[i]}");
            }
        }


    }
}
