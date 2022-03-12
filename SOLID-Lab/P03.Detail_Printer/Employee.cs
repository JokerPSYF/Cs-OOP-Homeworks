using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Employee : IDetailsPrinter, IPerson
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public void Print()
        {
            Console.WriteLine(Name);
        }
    }
}
