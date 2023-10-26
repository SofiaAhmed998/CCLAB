using System;

class SymbolTable<TKey, TValue>
{
    private TKey[] keys;
    private TValue[] values;
    private int size;

    public SymbolTable(int capacity)
    {
        keys = new TKey[capacity];
        values = new TValue[capacity];
        size = 0;
    }

    public void Add(TKey key, TValue value)
    {
        if (size >= keys.Length)
        {
            // You can implement resizing logic here if needed.
            throw new InvalidOperationException("Symbol table is full.");
        }

        keys[size] = key;
        values[size] = value;
        size++;
    }

    public TValue Get(TKey key)
    {
        for (int i = 0; i < size; i++)
        {
            if (keys[i].Equals(key))
            {
                return values[i];
            }
        }

        throw new KeyNotFoundException($"Key '{key}' not found in the symbol table.");
    }

    public int Size()
    {
        return size;
    }
}

class Program
{
    static void Main(string[] args)
    {
        SymbolTable<string, int> symbolTable = new SymbolTable<string, int>(10);

        symbolTable.Add("x", 10);
        symbolTable.Add("y", 20);
        symbolTable.Add("z", 30);

        Console.WriteLine("Size of symbol table: " + symbolTable.Size());
        Console.WriteLine("Value of x: " + symbolTable.Get("x"));
        Console.WriteLine("Value of y: " + symbolTable.Get("y"));
        Console.WriteLine("Value of z: " + symbolTable.Get("z"));

        try
        {
            Console.WriteLine("Value of w: " + symbolTable.Get("w"));
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
