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
    public class AccessoryDAO : BaseDAO<Accessory>, IDao<Accessory>
    {

        public override int Insert(Accessory row)
        {
            return _db.InsertTable("accessory", row);
        }
        public override int Update(Accessory row)
        {
            return _db.UpdateTable("accessory", row);
        }
        public override bool Delete(Accessory row)
        {
            return _db.DeleteTable("accessory", row);
        }
        public override Accessory[] FindAll()
        {
            var result = _db.SelectTable("accessory", c => c.Id > 0);
            return result.Select(c => (Accessory)c).ToArray();
        }
        public override Accessory FindById(int id)
        {
            var result = _db.SelectTable("accessory", c => c.Id == id);
            if (result.Length == 0) return null;
            Accessory accessory = (Accessory)result.FirstOrDefault();
            return accessory;
        }

        public  Accessory FindByName(string name)
        {
            var result = _db.SelectTable("accessory", c => c.Name.Equals(name));
            if (result.Length == 0) return null;
            Accessory accessory = (Accessory)result.FirstOrDefault();
            return accessory;
        }

        public Accessory[] Search(Predicate<dynamic> where)
        {
            var result = _db.SelectTable("accessory", where);
            return result.Select(c => (Accessory)c).ToArray();
        }

       
    }
}
