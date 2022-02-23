using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            if (Count == 0)
            {
                return null;
            }
            Random random = new Random();
            int index = random.Next(0, Count);
            return this[index];
        }
    }
}