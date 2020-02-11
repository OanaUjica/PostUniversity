

namespace GenericCollectionsImplementedWithDynamicArray
{
    public interface IBag<T>
    {
        void Add(T element);
        bool Remove(T element);
        bool Search(T element);
        uint Length();

    }
}
