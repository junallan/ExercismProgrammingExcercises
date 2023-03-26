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
        var numberOfValues = values.Count();

        if (numberOfValues > 0)
        {
            _value = values.ElementAt(0);

            if (numberOfValues == 1) return;

            var currentNode = this;

            for (int i = 1; i < values.Count(); i++)
            {
                currentNode.Add(values.ElementAt(i));
                currentNode = currentNode.Next;
            }
        }
    }

    public T Value 
    { 
        get
        {
            return _value;
        } 
    }

    public SimpleLinkedList<T> Next
    { 
        get
        {
            return _nextNode;
        } 
    }

    public SimpleLinkedList<T> Add(T value)
    {

        var newNode = new SimpleLinkedList<T>(value);
        _nextNode = newNode;

        return this;
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        var currentNode = this;

        do
        {
            yield return currentNode.Value;
            currentNode = currentNode._nextNode;

        } while (currentNode != null);
    }
}