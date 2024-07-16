using lesson1.DAO;
using Lesson1.Interfaces;
using lesson1.MuckEntity;
using System;
using System.Linq;

namespace Lesson1.Base
{
    public abstract class BaseDAO<T> : IDao<T> where T : BaseRow
    {
        protected readonly Database _db;

        // Constructor initializes the Database instance
        public BaseDAO()
        {
            _db = Database.Instance;
        }

        /**
         * Inserts a row into the database table associated with type T.
         * @param row The row object to insert.
         * @return The index of the inserted row if successful, -1 otherwise.
         */
        public int Insert(T row)
        {
            string name = typeof(T).Name.ToLower();
            return _db.InsertTable(name, row);
        }

        /**
         * Updates a row in the database table associated with type T.
         * @param row The updated row object.
         * @return The index of the updated row if successful, -1 otherwise.
         */
        public int Update(T row)
        {
            string name = typeof(T).Name.ToLower();
            return _db.UpdateTable(name, row);
        }

        /**
         * Deletes a row from the database table associated with type T.
         * @param row The row object to delete.
         * @return True if the row was deleted successfully, false otherwise.
         */
        public bool Delete(T row)
        {
            string name = typeof(T).Name.ToLower();
            return _db.DeleteTable(name, row);
        }

        /**
         * Retrieves all rows from the database table associated with type T.
         * @return An array of all rows of type T in the database.
         */
        public T[] FindAll()
        {
            string name = typeof(T).Name.ToLower();
            var result = _db.SelectTable(name, e => e.Id > int.MinValue);
            return result.Select(e => (T)e).ToArray();
        }

        /**
         * Retrieves a row from the database table associated with type T by its ID.
         * @param id The ID of the row to retrieve.
         * @return The row of type T with the specified ID, or null if not found.
         */
        public T FindById(int id)
        {
            string name = typeof(T).Name.ToLower();
            var result = _db.SelectTable(name, c => c.Id == id);
            if (result.Length == 0) return null;
            T response = (T)result.FirstOrDefault();
            return response;
        }

        /**
         * Retrieves a row from the "product" table by its name.
         * @param name The name to search for in the "product" table.
         * @return The row of type T with the specified name, or null if not found.
         */
        public T FindByName(string name)
        {
            var result = _db.SelectTable("product", c => c.Name.Equals(name));
            if (result.Length == 0) return null;
            T response = (T)result.FirstOrDefault();
            return response;
        }

        /**
         * Searches for rows in the database table associated with type T using a predicate condition.
         * @param where The predicate function to filter rows.
         * @return An array of rows of type T that satisfy the predicate condition.
         */
        public T[] Search(Predicate<dynamic> where)
        {
            string name = typeof(T).Name.ToLower();
            var result = _db.SelectTable(name, where);
            return result.Select(e => (T)e).ToArray();
        }
    }
}
