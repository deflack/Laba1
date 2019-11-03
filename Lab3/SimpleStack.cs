using System;

namespace Lab3
{
    class SimpleStack<T> : SimpleList<T> where T : IComparable<T>
    {
        public void Push(T element)
        {
            Add(element);
        }
        public T Pop()
        {
            if (Count == 0)
                throw new Exception("В стеке нет элементов");
            else
            {
                SimpleListItem<T> current = first;
                T itemData = last.data;
                if (current.next == null)
                    last = null;
                else
                {
                    while (current.next != last)
                    {
                        current = current.next;
                    }
                    current.next = null;
                    last = current;
                }
                Count--;
                return itemData;
            }
        }
    }
}
