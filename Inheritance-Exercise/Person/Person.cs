using System;
using System.Linq.Expressions;
using System.Text;

namespace Person
{
    public class Person
    {
        public string name;

        public int age;

        public string Name{ get => name; set => name = value; }

        public int Age
        {
            get => age;
            set
            {
                if (value < 0 )
                {
                    throw new Exception();
                }

                else
                {
                    age = value;
                }
            }
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                this.Name,
                this.Age));

            return stringBuilder.ToString();
        }
    }
}