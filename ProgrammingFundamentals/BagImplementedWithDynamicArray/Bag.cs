using System.Collections;
using System.Collections.Generic;

namespace GenericCollectionsImplementedWithDynamicArray
{
    internal class Bag<T> : IBag<T>, IEnumerable<T>
    {
        private T[] elements;
        private uint capacity;
        private uint length;

        public Bag()
        {
            this.capacity = 20;
            this.length = 0;
            this.elements = new T[capacity]; 
        }

        public void Add(T newElement)
        {
            if (this.capacity == this.length)
            {
                Resize();
            }

            elements[this.length] = newElement;
            this.length++;
        }

        public bool Remove(T element)
        {
            bool found = false;
            int index = 0;

            while (index < this.length && found == false)
            {
                if (this.elements[index].Equals(element))
                {
                    found = true;
                }
                else
                {
                    index++;
                }
            }

            if (found)
            {
                this.elements[index] = this.elements[length - 1];
                this.length--;
            }
            return found;
        }

        public bool Search(T element)
        {
            for (int i = 0; i < length; i++)
            {
                if (elements[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        public uint Length()
        {
            return this.length;
        }

        private void Resize()
        {
            this.capacity *= 2;
            T[] aux = new T[this.capacity];

            for (int i = 0; i < elements.Length; i++)
            {
                aux[i] = elements[i];
            }
            this.elements = aux;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int count = 0;
            foreach (var item in elements)
            {
                if (count < length)
                {
                    yield return item;
                }
                count++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }

}
