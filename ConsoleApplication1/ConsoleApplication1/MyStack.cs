using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MyStack<T>
    {
        private StackElement<T> startElement;

        public MyStack()
        {
            startElement = null;
        }

        public void Push (T value)
        {
            StackElement<T> element = new StackElement<T>(value, startElement);
            startElement = element;

        }
        public T Pop()
        {
            StackElement<T> temp = startElement;
            if (startElement == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                startElement = startElement.next;
                return temp.value;
            }
        }
        public T Peek()
        {
            return startElement.value;
        }
    }
}
