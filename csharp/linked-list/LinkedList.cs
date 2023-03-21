using System;

public class Node<T>
{
    public T Value { get; set; }
    public Node<T> PreviousNode { get; set; }
    public Node<T> NextNode { get; set; }
}

public class NodeList<T>
{
    public Node<T> FirstNode { get; set; }
    public Node<T> LastNode { get; set; }
}

public class Deque<T>
{
    private NodeList<T> elements = new NodeList<T>();

    public void Push(T value)
    {
        var newNode = new Node<T> { Value = value };

        if (elements.FirstNode == null)
        {
            elements.FirstNode = newNode;
            elements.LastNode = elements.FirstNode;
        }
        else
        {
            var oldLastNode = elements.LastNode;
            elements.LastNode = newNode;
            elements.LastNode.PreviousNode = oldLastNode;
            oldLastNode.NextNode = elements.LastNode;
        }
    }

    public T Pop()
    {
        var value = elements.LastNode.Value;

        if (elements.FirstNode == elements.LastNode)
        {
            elements.FirstNode = null;
            elements.LastNode = null;
        }
        else
            elements.LastNode = elements.LastNode.PreviousNode;

        return value;
    }

    public void Unshift(T value)
    {
        var newNode = new Node<T> { Value = value };
        var oldFirstNode = elements.FirstNode;
        elements.FirstNode = newNode;

        if(oldFirstNode != null)
        {
            elements.FirstNode.NextNode = oldFirstNode;
            oldFirstNode.PreviousNode = elements.FirstNode;
        }
    }

    public T Shift()
    {
        var value = elements.FirstNode.Value;

        if (elements.FirstNode == elements.LastNode)
        {
            elements.FirstNode = null;
            elements.LastNode = null;
        }
        else
            elements.FirstNode = elements.FirstNode.NextNode; 

        return value;

    }
}