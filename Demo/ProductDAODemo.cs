using Lesson1.DAO;
using lesson1.MuckEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Demo
{
    public class ProductDAODemo
    {
        private readonly ProductDAO _productDAO;
        public ProductDAODemo()
        {
            _productDAO = new ProductDAO();
        }

        public void InsertTest()
        {
            Product mockProduct1 = new Product(1, "MacBook Air M1", "Apple", 999.99, 5);
            Product mockProduct2 = new Product(2, "Surface Pro 7", "Microsoft", 799.99, 3);
            _productDAO.Insert(mockProduct1);
            _productDAO.Insert(mockProduct2);
            FindAllTest();
            Console.WriteLine();
        }

        public void UpdateTest()
        {
            Product mockProduct1 = new Product(2, "MacBook Pro M2", "Apple", 1000.0, 3);
            _productDAO.Update(mockProduct1);
            FindAllTest();
        }

        public void DeleteTest()
        {
            Product mockProduct1 = new Product(1, "MacBook Air M1", "Apple", 999.99, 5);
            _productDAO.Delete(mockProduct1);
            FindAllTest();
        }

        public void FindAllTest()
        {
            var result = _productDAO.FindAll();
            Array.ForEach(result, product =>
            {
                Console.WriteLine(product);
            });
        }

        public void FindByIdTest()
        {
            var result = _productDAO.FindById(2);
            Console.WriteLine(result);
        }

        public void FindByNameTest()
        {
            var result = _productDAO.FindByName("MacBook Air M1");
            Console.WriteLine(result);
        }

        public void Search()
        {
            var result = _productDAO.Search(p => p.Id > 1);
            Array.ForEach(result, product =>
            {
                Console.WriteLine(product);
            });
        }

    }
}
