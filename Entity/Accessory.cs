using Lesson1.Base;
using Lesson1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson1.MuckEntity
{
    public class Accessory : BaseRow
    {
        public Accessory(int id, string name): base(id, name) { }
       
        public override string ToString()
        {
            return $"Accessory ID: {Id}, Accessory name: {Name}";
        }
    }
}