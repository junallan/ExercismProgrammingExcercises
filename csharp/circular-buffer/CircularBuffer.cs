using System;
using System.Linq;

public class CircularBuffer<T>
{
    private T[] _bufferData;
    private int _startIndex;
    private int _itemsAdded;
     

    public CircularBuffer(int capacity)
    {
        _bufferData = new T[capacity];
    }

    public T Read()
    {
        if(_itemsAdded == 0) { throw new InvalidOperationException(); }

        _itemsAdded--;

        var readData = _bufferData[_startIndex];

        _startIndex = ++_startIndex % _bufferData.Length;

        return readData;
    }

    public void Write(T value)
    {
        if (_itemsAdded == _bufferData.Length) { throw new InvalidOperationException(); }
        //_startIndex = ++_startIndex % _bufferData.Length;

        _bufferData[_startIndex + _itemsAdded] = value;
        _itemsAdded++;
    }

    public void Overwrite(T value)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public void Clear()
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}