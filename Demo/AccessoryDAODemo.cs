using lesson1.MuckEntity;
using Lesson1.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Demo
{
    public class AccessoryDAODemo
    {
        private readonly AccessoryDAO _accessoryDAO;
        public AccessoryDAODemo()
        {
            _accessoryDAO = new AccessoryDAO();
        }
        
        public void InsertTest()
        {
            Accessory mockAccessory1 = new Accessory(1, "Wireless Mouse");
            Accessory mockAccessory2 = new Accessory(2, "Mechanical Keyboard");
            _accessoryDAO.Insert(mockAccessory1);
            _accessoryDAO.Insert(mockAccessory2);
            FindAllTest();
            Console.WriteLine();
        }

        public void UpdateTest()
        {
            Accessory mockAccessory2 = new Accessory(2, "Mechanical Keyboard Vip Pro");
            _accessoryDAO.Update(mockAccessory2);
            FindAllTest();
        }

        public void DeleteTest()
        {
            Accessory mockAccessory1 = new Accessory(1, "Wireless Mouse");
            _accessoryDAO.Delete(mockAccessory1);
            FindAllTest();
        }

        public void FindAllTest()
        {
            var result = _accessoryDAO.FindAll();
            Array.ForEach(_accessoryDAO.FindAll(), accessory =>
            {
                Console.WriteLine(accessory);
            });
        }

        public void FindByIdTest()
        {
            var result = _accessoryDAO.FindById(1);
            Console.WriteLine(result);
        }
        public void FindByNameTest()
        {
            var result = _accessoryDAO.FindByName("Wireless Mouse");
            Console.WriteLine(result);
        }

        public void Search()
        {
            var result = _accessoryDAO.Search(p => p.Name.Equals("Wireless Mouse"));
            Array.ForEach(result, accessrory =>
            {
                Console.WriteLine(accessrory);
            });
        }


    }
}
