using System;
using System.Collections.Generic;
using System.Text;

namespace StackOfStrings
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
                Push(element);
            }

            return this;
        }
    }
}
