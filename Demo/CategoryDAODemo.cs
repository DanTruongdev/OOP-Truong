using lesson1.MuckEntity;
using Lesson1.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Demo
{
    internal class CategoryDAODemo
    {
        private readonly CategoryDAO _categoryDAO;
        public CategoryDAODemo()
        {
            _categoryDAO = new CategoryDAO();
        }
        
        public void InsertTest()
        {
            Category mockCategory1 = new Category(1, "Laptops");
            Category mockCategory2 = new Category(2, "Smartphones");
            _categoryDAO.Insert(mockCategory1);
            _categoryDAO.Insert(mockCategory2);
            FindAllTest();
            Console.WriteLine();
        }

        public void UpdateTest()
        {
            Category mockCategory1 = new Category(1, "Laptops Updated");
            _categoryDAO.Update(mockCategory1);
            FindAllTest();
        }

        public void DeleteTest()
        {
            Category mockCategory2 = new Category(2, "Smartphones");
            _categoryDAO.Delete(mockCategory2);
            FindAllTest();
        }

        public void FindAllTest()
        {
            var result = _categoryDAO.FindAll();
            Array.ForEach(_categoryDAO.FindAll(), category =>
            {
                Console.WriteLine(category);
            });
        }

        public void FindByIdTest()
        {
            var result = _categoryDAO.FindById(1);
            Console.WriteLine(result);
        }


    }
}
