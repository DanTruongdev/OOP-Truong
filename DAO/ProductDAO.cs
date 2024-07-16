using lesson1.DAO;
using lesson1.MuckEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.DAO
{
    public class ProductDAO
    {
        private readonly Database _db;
        public ProductDAO()
        {
            _db = Database.Instance;
        }
        public int Insert(Product row)
        {
            return _db.InsertTable("product", row);
        }
        public int Update(Product row)
        {
            return _db.UpdateTable("product", row);
        }
        public bool Delete(Product row)
        {
            return _db.DeleteTable("product", row);
        }
        public Product[] FindAll()
        {
            var result = _db.SelectTable("product", c => c.Id > 0);
            return result.Select(c => (Product)c).ToArray();
        }
        public Product FindById(int id)
        {
            var result = _db.SelectTable("product", c => c.Id == id);
            if (result.Length == 0) return null;
            Product product = (Product)result.FirstOrDefault();
            return product;
        }

        public Product FindByName(string name)
        {
            var result = _db.SelectTable("product", c => c.Name.Equals(name));
            if (result.Length == 0) return null;
            Product product = (Product)result.FirstOrDefault();
            return product;
        }

        public Product[] Search(Predicate<dynamic> where)
        {
            var result = _db.SelectTable("product", where);
            return result.Select(c => (Product)c).ToArray();
        }
    }
}
