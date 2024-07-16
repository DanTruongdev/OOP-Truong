using Lesson1.Interfaces;
using System;

namespace Lesson1.Base
{
    // Abstract base class implementing IEntity interface
    public abstract class BaseRow : IEntity
    {
        // Private field for ID
        private int _id { get; set; }

        // Public property for ID
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        // Public property for Name
        public string Name { get; set; }

        // Constructor to initialize ID and Name
        public BaseRow(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /**
         * Prints a string representation of the object to the console.
         * This method overrides the default ToString method.
         */
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }

        // Override ToString to provide a custom string representation
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}";
        }
    }
}
