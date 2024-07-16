using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lesson1.MuckEntity;

namespace lesson1.Demo
{
    public class ProductDemo
    {
        public  Product CreateProduct(){
            return new Product(1, "MacBook Air M1", "Apple", 200.0, 1);
        }
        public void PrintProduct(Product product){
            Console.WriteLine(product.ToString());
        }
    }
}