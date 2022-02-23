using System.Collections;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return Count == 0;
        }

        public Stack<string> AddRange(IEnumerable<string> elements)
        {
            foreach (string element in elements)
            {
                this.Push(element);
            }

            return this;
        }
    }
}