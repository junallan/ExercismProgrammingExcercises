using System;

public class Deque<T>
{
private Node FirstNode { get; set; }
private Node LastNode { get; set; }
    

    public class Node
    {
        public T Value { get; set; }
        public Node PreviousNode { get; set; }
        public Node NextNode { get; set; }
    }

    
    public void Push(T value)
    {
        var newNode = new Node { Value = value };

        if (FirstNode == null)
        {
            FirstNode = newNode;
            LastNode = FirstNode;
        }
        else
        {
            var oldLastNode = LastNode;
            LastNode = newNode;
            LastNode.PreviousNode = oldLastNode;
            oldLastNode.NextNode = LastNode;
        }
    }

    public T Pop()
    {
        var value = LastNode.Value;

        if (FirstNode == LastNode)
        {
            FirstNode = null;
            LastNode = null;
        }
        else
            LastNode = LastNode.PreviousNode;

        return value;
    }

    public void Unshift(T value)
    {
        var newNode = new Node { Value = value };
        var oldFirstNode = FirstNode;
        FirstNode = newNode;

        if (oldFirstNode == null)
            LastNode = FirstNode;
        else
        {
            FirstNode.NextNode = oldFirstNode;
            oldFirstNode.PreviousNode = FirstNode;
        }
    }

    public T Shift()
    {
        var value = FirstNode.Value;

        if (FirstNode == LastNode)
        {
            FirstNode = null;
            LastNode = null;
        }
        else
            FirstNode = FirstNode.NextNode; 

        return value;
    }
}