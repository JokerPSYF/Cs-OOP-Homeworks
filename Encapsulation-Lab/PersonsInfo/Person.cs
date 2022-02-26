using System;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private decimal salary;
        private int age;

        public string FirstName
        {
            get => firstName;
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                else
                {
                    firstName = value;
                }
            }
        }
        public string LastName
        {
            get => lastName;
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
                else
                {
                    lastName = value;
                }
            }

        }

        public decimal Salary
        {
            get => salary;
            private set
            {
                if (value < 650.00m)
                {
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                }
                else
                {
                    salary = value;
                }
            }
        }

        public int Age
        {
            get => age;
            private set
            {
                if (value > 0)
                {
                    age = value;
                }
                else
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
            }
        }

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            Age = age;
        }

      //  public override string ToString() => $"{FirstName} {LastName} receives {Salary:f2} leva.";

        //public void IncreaseSalary(decimal percentage)
        //{
        //    if (Age < 30) percentage /= 2;

        //    Salary += percentage / 100 * Salary;
        //}
    }
}