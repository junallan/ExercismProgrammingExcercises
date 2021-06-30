using System;

public class CircularBuffer<T>
{
    private T[] _bufferData;
    private int _startIndex;
    private int _endIndex;

    public CircularBuffer(int capacity)
    {
        _bufferData = new T[capacity];
    }

    public T Read()
    {
        if (_startIndex == _endIndex) { throw new InvalidOperationException(); }

        return _bufferData[_startIndex++];
    }

    public void Write(T value)
    {
        _bufferData[_endIndex++] = value;

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