using lesson1.DAO;
using lesson1.MuckEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Base
{
    public abstract class BaseDAO<T> where T : BaseRow
    {
        protected readonly Database _db;
        public BaseDAO()
        {
            _db = Database.Instance;
        }
        public abstract int Insert(T row);
        public abstract int Update(T row);
        public abstract bool Delete(T row);
        public abstract T[] FindAll();
        public abstract T FindById(int id);
    }
}
