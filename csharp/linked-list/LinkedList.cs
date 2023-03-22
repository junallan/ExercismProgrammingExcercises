using System;

public class Deque<T>
{
    private Node firstNode;
    private Node lastNode;
    
    private class Node
    {
        public T Value { get; set; }
        public Node PreviousNode { get; set; }
        public Node NextNode { get; set; }
    }

    
    public void Push(T value)
    {
        var newNode = new Node { Value = value };

        if (firstNode == null)
        {
            firstNode = newNode;
            lastNode = firstNode;
        }
        else
        {
            var oldLastNode = lastNode;
            lastNode = newNode;
            lastNode.PreviousNode = oldLastNode;
            oldLastNode.NextNode = lastNode;
        }
    }

    public T Pop()
    {
        var value = lastNode.Value;

        if (firstNode == lastNode)
        {
            firstNode = null;
            lastNode = null;
        }
        else
            lastNode = lastNode.PreviousNode;

        return value;
    }

    public void Unshift(T value)
    {
        var newNode = new Node { Value = value };
        var oldFirstNode = firstNode;
        firstNode = newNode;

        if (oldFirstNode == null)
            lastNode = firstNode;
        else
        {
            firstNode.NextNode = oldFirstNode;
            oldFirstNode.PreviousNode = firstNode;
        }
    }

    public T Shift()
    {
        var value = firstNode.Value;

        if (firstNode == lastNode)
        {
            firstNode = null;
            lastNode = null;
        }
        else
            firstNode = firstNode.NextNode; 

        return value;
    }
}