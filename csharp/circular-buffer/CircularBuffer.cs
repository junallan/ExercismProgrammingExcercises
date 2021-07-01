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
      
        _bufferData[(_startIndex + _itemsAdded) % _bufferData.Length] = value;
        _itemsAdded++;
    }

    public void Overwrite(T value)
    {
        _bufferData[(_startIndex + _itemsAdded) % _bufferData.Length] = value;

        if (_itemsAdded == _bufferData.Length)
        {
            _startIndex = ++_startIndex % _bufferData.Length;
        }
        else
        {
            _itemsAdded++;
        }
    }

    public void Clear()
    {
        _bufferData = new T[_bufferData.Length];
        _startIndex = 0;
        _itemsAdded = 0;
    }
}