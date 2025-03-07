public class List<T>
{
    // Fields
    private T[] items;
    private int capacity;
    private int count;
    private int growth;
 
    // Properties
    public int Capacity => capacity;
    public int Count => count;
    public T this[int index]
    {
        get => GetItem(index);
        set => SetItem(index, value);
    }
 
    // Constructors
    public List()
    {
        growth = 2;   
        count = 0;
        capacity = growth;
        items = new T[capacity];
    }
 
    // Methods
    public void Add(T item)
    {
        if (count >= capacity)
        {
            T[] temp = items;
            capacity *= growth;
            items = new T[capacity];
            for (int i = 0; i < count; i++)
            {
                items[i] = temp[i];
            }
        }
        items[count] = item;
        count++;
    }
    public void Remove(T item)
    {
        for (int i = 0; i < count; i++)
        {
            if (item == null && items[i] == null 
                || item!.Equals(items[i]))
            {
                for (int j = i; j < count - 1; j++)
                {
                    items[j] = items[j + 1];
                }
                count--;
                return;
            }
        }
    }
    private T GetItem(int index)
    {
        if (index >= count || index < 0)
            throw new ArgumentOutOfRangeException("Index is out of bonds of the list.");
        return items[index];
    }
    private void SetItem(int index, T item)
    {
        if (index >= count || index < 0)
            throw new ArgumentOutOfRangeException("Index is out of bonds of the list.");
        items[index] = item;
    }
}