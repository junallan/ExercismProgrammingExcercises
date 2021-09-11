using System;
using System.Collections.Generic;
using System.Linq;

public class CircularBuffer<T>
{
    private Queue<T> _bufferData;
    private int _capacity;     

    public CircularBuffer(int capacity)
    {
        _bufferData = new Queue<T>(capacity);
        _capacity = capacity;
    }

    public T Read() => !_bufferData.Any() ? throw new InvalidOperationException() : _bufferData.Dequeue();

    public void Write(T value)
    {
        if (_bufferData.Count == _capacity) throw new InvalidOperationException(); 

        _bufferData.Enqueue(value);
    }

    public void Overwrite(T value)
    {
        if (_bufferData.Count == _capacity) _bufferData.Dequeue();

        _bufferData.Enqueue(value);
    }

    public void Clear() => _bufferData.Clear();
}