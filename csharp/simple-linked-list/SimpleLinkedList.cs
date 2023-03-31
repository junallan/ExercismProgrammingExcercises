using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    private T _value;
    private SimpleLinkedList<T> _nextNode;

    public SimpleLinkedList(T value)
    {
        _value = value;
    }

    public SimpleLinkedList(IEnumerable<T> values)
    {
        if (values.Any())
        {
            _value = values.ElementAt(0);

            var currentNode = this;
            foreach(var item in values.Skip(1))
            {
                currentNode.Add(item);
                currentNode = currentNode.Next;
            }
        }
    }

    public T Value => _value;

    public SimpleLinkedList<T> Next => _nextNode;

    public SimpleLinkedList<T> Add(T value)
    {
        _nextNode = new SimpleLinkedList<T>(value);

        return this;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = this;

        do
        {
            yield return currentNode.Value;
            currentNode = currentNode._nextNode;

        } while (currentNode != null);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();   
}