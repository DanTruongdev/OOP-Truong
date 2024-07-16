using Lesson1.Base;

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

        /**
          * Find a row by its name in the T array.
          * @param name The name of the object to be found.
          * @return The object with the specified name, or null if not found.
          */
        public T FindByName(string name);

        /**
         * Search for objects in the array that match the specified condition.
         * @param where A Predicate that defines the condition to match the objects.
         * @return An array of objects that match the specified condition, or empty array if there are no elements met the condition.
         */
        public T[] Search(Predicate<dynamic> where);
    }
}
