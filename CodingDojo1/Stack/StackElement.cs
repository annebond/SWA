using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingDojo1.Stack
{
    class StackElement<T> //generics, to be type safe
    {
        public T ValueOfElement { get; set; } //Stores the value of the stack entry
        public StackElement<T> Successor { get; set; } //points to the successor of this entry => the entry which was added before this one. I don't need to remember all, just the entry before 'me'. Every entry remembers that one before him
    }
}
