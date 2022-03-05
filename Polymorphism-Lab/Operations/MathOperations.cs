using System;

namespace Operations
{
    public class MathOperations
    {
        //Add(int, int) : int
        //Add(double, double, double) : double
        //Add(decimal, decimal, decimal) : decimal

       public int Add(int a, int b) => a + b;

        public double Add(double a, double b, double c) => a + b + c;

        public  decimal Add(decimal a, decimal b, decimal c) => a + b + c;
    }
}