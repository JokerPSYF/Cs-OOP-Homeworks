using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {


                List<Person> persons = new List<Person>();

                string[] personsInput = Console.ReadLine()
                    .Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int i = 0; i < personsInput.Length; i += 2)
                {
                    Person person = new Person(personsInput[i], int.Parse(personsInput[i + 1]));
                    persons.Add(person);
                }

                List<Product> products = new List<Product>();

                string[] productsInput = Console.ReadLine()
                    .Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();


                for (int i = 0; i < productsInput.Length; i += 2)
                {
                    Product product = new Product(productsInput[i], int.Parse(productsInput[i + 1]));
                    products.Add(product);
                }

                string[] cmd = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                while (cmd[0] != "END")
                {
                    string name = cmd[0];
                    string product = cmd[1];

                    persons.First(x => x.Name == name).BuyProduct(products.First(p => p.Name == product));

                    cmd = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                }

                foreach (var person in persons)
                {
                    List<string> productsOfPerson = new List<string>();
                    foreach (Product product in person.BagOfProducts)
                    {
                        productsOfPerson.Add(product.Name);
                    }
                    if (person.BagOfProducts.Count == 0)
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} - {string.Join(", ", productsOfPerson)}");
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}