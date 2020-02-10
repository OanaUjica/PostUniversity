

namespace GenericCollectionsImplementedWithDynamicArray
{
    internal class Bag<T> : IBag<T>
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
    }

}
