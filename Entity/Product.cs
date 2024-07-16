using Lesson1.Base;
using Lesson1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson1.MuckEntity
{
    public class Product : BaseRow, IEntity
    {
        public string Brand { get; set; }
        public double Price { get; set; }
        public  int CategoryId { get;  set; }

        public Product(int id, string name, string brand, double price, int categoryId) : base(id, name)
        {
            Brand = brand;
            Price = price;
            CategoryId = categoryId;
        }

        public override string ToString()
        {
            return $"Product ID: {Id}, Product name: {Name}, Product brand: {Brand}, Product price: {Price}, CategoryId: {CategoryId}";
        }
    }
}