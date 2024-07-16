
using lesson1.MuckEntity;
using lesson1.Demo;
using Lesson1.Demo;

namespace Lesson1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ProductDemo productDemo = new ProductDemo();
            //Product newProduct = productDemo.CreateProduct();
            //productDemo.PrintProduct(newProduct);


            //DatabaseDemo demo = new DatabaseDemo();
            //demo.InitDatabase();
            //demo.InsertTableTest();
            //demo.SelectTableTest();
            //demo.UpdateTableTest();
            //demo.DeleteTableTest();
            //demo.TruncateTable();


            CategoryDAODemo categoryDAODemo = new CategoryDAODemo();
            categoryDAODemo.InsertTest();
            categoryDAODemo.UpdateTest();
            //categoryDAODemo.DeleteTest();
            //categoryDAODemo.FindByIdTest();


            //ProductDAODemo productDAODemo = new ProductDAODemo();
            //productDAODemo.InsertTest();
            //productDAODemo.UpdateTest();
            //productDAODemo.DeleteTest();
            //productDAODemo.FindByIdTest();
            //productDAODemo.FindByNameTest();
            //productDAODemo.Search();

            //AccessoryDAODemo accessoryDAODemo = new AccessoryDAODemo();
            //accessoryDAODemo.InsertTest();
            //accessoryDAODemo.UpdateTest();
            //accessoryDAODemo.DeleteTest();
            //accessoryDAODemo.FindByIdTest();
            //accessoryDAODemo.FindByNameTest();
            //accessoryDAODemo.Search();




        }


    }
   
}
