using lesson1.DAO;
using Lesson1.Interfaces;
using lesson1.MuckEntity;
namespace Lesson1.Base
{
    public abstract class BaseDAO<T> : IDao<T> where T : BaseRow
    {
        protected readonly Database _db;
        public BaseDAO()
        {
            _db = Database.Instance;
        }
        public int Insert(T row)
        {
            string name = typeof(T).Name.ToLower();
            return _db.InsertTable(name, row);
        }
        public int Update(T row)
        {
            string name = typeof(T).Name.ToLower();
            return _db.UpdateTable(name, row);
        }
        public  bool Delete(T row)
        {
            string name = typeof(T).Name.ToLower();
            return _db.DeleteTable(name, row);
        }
        
        public T[] FindAll()
        {
            string name = typeof(T).Name.ToLower();
            var result = _db.SelectTable(name, e => e.Id > int.MinValue);
            return result.Select(e => (T)e).ToArray();
        }
        public T FindById(int id)
        {
            string name = typeof(T).Name.ToLower();
            var result = _db.SelectTable(name, c => c.Id == id);
            if (result.Length == 0) return null;
            T response = (T)result.FirstOrDefault();
            return response;
        }

        public T FindByName(string name)
        {
            var result = _db.SelectTable("product", c => c.Name.Equals(name));
            if (result.Length == 0) return null;
            T response = (T)result.FirstOrDefault();
            return response;
        }

        public T[] Search(Predicate<dynamic> where)
        {
            string name = typeof(T).Name.ToLower();
            var result = _db.SelectTable(name, where);
            return result.Select(e => (T)e).ToArray();
        }
    }
}
