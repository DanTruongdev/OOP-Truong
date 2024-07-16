using lesson1.DAO;
using lesson1.MuckEntity;
using Lesson1.Base;
using Lesson1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.DAO
{
    public class CategoryDAO : BaseDAO<Category>, IDao<Category>
    {
       
        public override int Insert(Category row)
        {
            return _db.InsertTable("category", row);
        }
        public override int Update(Category row)
        {
            return _db.UpdateTable("category", row);
        }
        public override bool Delete(Category row)
        {
            return _db.DeleteTable("category", row);
        }
        public override Category[] FindAll()
        {
            var result = _db.SelectTable("category", c => c.Id > 0);
            return result.Select(c => (Category)c).ToArray();
        }
        public override Category FindById(int id)
        {
            var result = _db.SelectTable("category", c => c.Id == id);
            if (result.Length == 0) return null;
            Category category = (Category) result.FirstOrDefault();
            return category;
        }
    }
}
