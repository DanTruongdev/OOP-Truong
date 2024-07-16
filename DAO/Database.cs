
using lesson1.MuckEntity;
using Lesson1.Base;

namespace lesson1.DAO
{
    public class Database
    {
        private Product[] ProductTable { get; set; }
        private Category[] CategoryTable { get; set; }
        private Accessory[] AccessoryTable { get; set; }

        private static Database _instance = new Database();
        public static Database Instance { get { return _instance; } }
        private Database()
        {
            ProductTable = new Product[100];
            CategoryTable = new Category[100];
            AccessoryTable = new Accessory[100];
        }

        public int InsertTable(string name, BaseRow row)
        {
            var arr = GetArray(name);
            if (arr == null) return -1;
            int currentIndex = 0;
            while (currentIndex < arr.Length && arr[currentIndex] != null)
            {
                currentIndex++;
            }
            if (currentIndex == arr.Length) return -1;
            arr[currentIndex] = row;
            return currentIndex;
        }


        public dynamic[] SelectTable(string name, Predicate<dynamic> where)
        {
            
            var arr = GetArray(name);
            if (arr == null) return new dynamic[0];
            var result = Array.FindAll(arr.Where(e => e != null).ToArray(), where);
            return result;
        }

        public int UpdateTable(string name, BaseRow row)
        {
            var arr = GetArray(name);
            if (arr == null) return -1;
            int currentIndex = Array.FindIndex(arr, 0, arr.Length, e => e != null && e.Id == row.Id);
            if (currentIndex == -1) return -1;
            arr[currentIndex] = row;
            return currentIndex;
        }

        public bool DeleteTable(string name, BaseRow row)
        {
            var arr = GetArray(name);
            if (arr == null) return false;
            var tempArr = arr.Where(e => e != null).ToArray();
            int currentIndex = Array.FindIndex(tempArr, 0, tempArr.Length, e => e != null && e.Id == row.Id);
            if (currentIndex == -1) return false;
            for (int i = currentIndex; i < arr.Length-2; i++)
            {
                arr[i] = arr[i + 1];
            }
            arr[arr.Length-1] = null;
            return true;
        }

        public void TruncateTable(string name)
        {
            var arr = GetArray(name);
            if (arr == null) Console.WriteLine("The name must be \"produt\", \"category\", or \"accessory\"");
            else
            {
                Array.Clear(arr, 0, arr.Length);
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == null) break;
                    Console.WriteLine($"arr[{i}] = {arr[i]}");
                }
            }
        }

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


        private dynamic[] GetArray(string name)
        {
            switch (name)
            {
                case "product":
                    return ProductTable;
                case "category":
                    return CategoryTable;
                case "accessory":
                    return AccessoryTable;
                default:
                    return null;
            }
        }
    }
   
}

