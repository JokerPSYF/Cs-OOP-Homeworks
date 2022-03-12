using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class Manager : IDetailsPrinter, IPerson
    {
        public string Name { get; set; }

        public Manager(string name, ICollection<string> documents)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public void Print()
        {
            Console.WriteLine(Name);
            Console.WriteLine(string.Join(Environment.NewLine, Documents));
        }

    }
}
