using lesson1.MuckEntity;
using Lesson1.Base;
using Lesson1.Common;
using System;
using System.Linq;

namespace lesson1.DAO
{
    public class Database
    {
        private Product[] ProductTable { get; set; }
        private Category[] CategoryTable { get; set; }
        private Accessory[] AccessoryTable { get; set; }
        
        // Singleton instance of the Database class
        private static Database _instance = new Database();
        public static Database Instance { get { return _instance; } }

        // Private constructor to prevent instantiation outside the class
        private Database()
        {
            ProductTable = new Product[0];
            CategoryTable = new Category[0];
            AccessoryTable = new Accessory[0];
        }

        /**
         * Inserts a new row into the specified table.
         * @param name The name of the table ("product", "category", "accessory").
         * @param row The row object to be inserted.
         * @return The index of the inserted row if successful, -1 otherwise.
         */
        public int InsertTable(string name, BaseRow row)
        {
            var arr = GetArray(name);
            if (arr == null) return -1;
            int addingIndex = arr.Length;
            Array.Resize(ref arr, addingIndex + 1);
            arr[addingIndex] = row;
            SetArray(name, arr);
            return addingIndex;
        }

        /**
         * Selects rows from the specified table based on a given condition.
         * @param name The name of the table ("product", "category", "accessory").
         * @param where The predicate function to filter rows.
         * @return An array of rows that satisfy the condition.
         */
        public dynamic[] SelectTable(string name, Predicate<dynamic> where)
        {
            var arr = GetArray(name);
            if (arr == null) return new dynamic[0];
            var result = Array.FindAll(arr.Where(e => e != null).ToArray(), where);
            return result;
        }

        /**
         * Updates a row in the specified table based on its ID.
         * @param name The name of the table ("product", "category", "accessory").
         * @param row The updated row object.
         * @return The index of the updated row if successful, -1 otherwise.
         */
        public int UpdateTable(string name, BaseRow row)
        {
            var arr = GetArray(name);
            if (arr == null) return -1;
            int currentIndex = Array.FindIndex(arr, 0, arr.Length, e => e.Id == row.Id);
            if (currentIndex == -1) return -1;
            arr[currentIndex] = row;
            return currentIndex;
        }

        /**
         * Deletes a row from the specified table based on its ID.
         * @param name The name of the table ("product", "category", "accessory").
         * @param row The row object to delete.
         * @return True if the row was deleted successfully, false otherwise.
         */
        public bool DeleteTable(string name, BaseRow row)
        {
            var arr = GetArray(name);
            if (arr == null) return false;
            int arrSize = arr.Length;
            int deleteIndex = Array.FindIndex(arr, 0, arrSize, e => e.Id == row.Id);
            if (deleteIndex == -1) return false;
            for (int i = deleteIndex; i < arr.Length - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            Array.Resize(ref arr, arrSize - 1);
            SetArray(name, arr);
            return true;
        }

        /**
         * Clears all rows from the specified table.
         * @param name The name of the table ("product", "category", "accessory").
         */
        public void TruncateTable(string name)
        {
            var arr = GetArray(name);
            if (arr == null) Console.WriteLine("The name must be \"product\", \"category\", or \"accessory\"");
            else
            {
                Array.Clear(arr, 0, arr.Length);
            }
        }

        /**
         * Updates a row in the specified table based on its ID.
         * @param id The ID of the row to update.
         * @param row The updated row object.
         * @return The index of the updated row if successful, -1 otherwise.
         */
        public int UpdateTableById(int id, BaseRow row)
        {
            string type = row.GetType().ToString().ToLower();
            var splitType = type.Split('.');
            var name = splitType[splitType.Length - 1];
            var arr = GetArray(name);
            if (arr == null) return -1;
            int currentIndex = Array.FindIndex(arr, 0, arr.Length, e => e != null && e.Id == id);
            if (currentIndex == -1) return -1;
            arr[currentIndex] = row;
            return currentIndex;
        }

        // Private method to retrieve the appropriate array based on table name
        private dynamic[] GetArray(string name)
        {
            switch (name.ToLower())
            {
                case TableName.Product:
                    return ProductTable;
                case TableName.Category:
                    return CategoryTable;
                case TableName.Accessory:
                    return AccessoryTable;
                default:
                    return null;
            }
        }

        // Private method to set the appropriate array based on table name
        private void SetArray(string name, dynamic[] newArray)
        {
            switch (name.ToLower())
            {
                case TableName.Product:
                    ProductTable = newArray.Select(p => (Product)p).ToArray();
                    break;
                case TableName.Category:
                    CategoryTable = newArray.Select(c => (Category)c).ToArray();
                    break;
                case TableName.Accessory:
                    AccessoryTable = newArray.Select(a => (Accessory)a).ToArray();
                    break;
            }
        }
    }
}
