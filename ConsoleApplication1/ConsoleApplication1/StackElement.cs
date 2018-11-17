using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class StackElement<T>
    {
        public T value;
        public StackElement<T> next;

        public StackElement(T value, StackElement<T> next)
        {
            this.value = value;
            this.next = next;
        }
    }
}
