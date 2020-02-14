using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCollectionsImplementedWithDynamicArray
{
    class Set<T> : ISet<T>
    {
        private int capacity;
        private int length;
        private T[] elements;

        public Set()
        {
            this.capacity = 20;
            this.length = 0;
            this.elements = new T[capacity];
        }

        private void Resize()
        {
            capacity *= 2;
            T[] aux = new T[capacity];

            for (int i = 0; i < length; i++)
            {
                aux[i] = elements[i];
            }
            elements = aux;
        }

        public void Add(T newElement)
        {
            bool found = false;
            for (int i = 0; i < length; i++)
            {
                if (elements[i].Equals(newElement))
                {
                    found = true;
                }
            }

            if (!found)
            {
                if (this.capacity == this.length)
                {
                    Resize();
                }

                this.elements[length] = newElement;
                this.length++;
            }
        }
    }
}
