using System;

namespace Stealer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.CollectGettersAnSetters("Stealer.Hacker");
            Console.WriteLine(result);
        }
    }
}
