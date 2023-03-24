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
        var newNode = new Node { Value = value, PreviousNode = lastNode };

        if (lastNode != null) lastNode.NextNode = newNode;

        lastNode = newNode;

        firstNode ??= lastNode;
    }

    public T Pop()
    {
        var value = lastNode.Value;

        (firstNode, lastNode)
            = firstNode == lastNode
            ? (null, null)
            : (firstNode, lastNode.PreviousNode);

        return value;
    }

    public void Unshift(T value)
    {
        var newNode = new Node { Value = value, NextNode = firstNode };
        
        if (firstNode == null)
            lastNode = newNode;
        else
            firstNode.PreviousNode = newNode;
        
        firstNode = newNode;
    }

    public T Shift()
    {
        var value = firstNode.Value;

        (firstNode, lastNode)
            = firstNode == lastNode
            ? (null, null)
            : (firstNode.NextNode, lastNode);

        return value;
    }
}