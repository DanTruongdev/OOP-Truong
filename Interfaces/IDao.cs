using Lesson1.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Interfaces
{
    public interface IDao<T> where T : BaseRow
    {
        /**
          * Insert a new row into the T array at the latest index.
          * @param row The object which is inserted into the T array.
          * @return The index of the inserted object if the row was successfully inserted, -1 otherwise.
          */
        public int Insert(T row);

        /**
         * Update an existing row in the T array.
         * @param row The object which is used to update the corresponding row in the T array.
         * @return The index of the updated object if the row was successfully updated, -1 otherwise.
         */
        public int Update(T row);

        /**
         * Delete a row from the T array.
         * @param row The object which is to be deleted from the T array.
         * @return True if the row was successfully deleted, false otherwise.
         */
        public bool Delete(T row);

        /**
         * Find all rows in the T array.
         * @return An array of all objects of type T. Empty array otherwise.
         */
        public T[] FindAll();

        /**
         * Find a row by its ID in the T array.
         * @param id The ID of the object to be found.
         * @return The object with the specified ID, or null if not found.
         */
        public T FindById(int id);
    }
}
