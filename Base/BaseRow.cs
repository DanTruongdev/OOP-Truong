using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Base
{
    public abstract class BaseRow
    {
        private int _id { get; set; }
        public int Id 
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name { get; set; }

        public BaseRow(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
