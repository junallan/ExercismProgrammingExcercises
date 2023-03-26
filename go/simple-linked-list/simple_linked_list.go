package linkedlist

import "errors"

type List struct {
	first *Node
	last  *Node
	count int
}

type Node struct {
	next  *Node
	Value int
}

//var list List

func New(elements []int) *List {
	l := &List{}
	for _, item := range elements {
		l.Push(item)
	}

	return l
}

func (l *List) Size() int {
	return l.count
	// var itemCount int = 0
	// currentNode := list.first

	// for currentNode != nil {
	// 	itemCount++
	// 	currentNode = currentNode.next
	// }

	// return itemCount
}

func (l *List) Push(element int) {
	newNode := &Node{Value: element}
	currentNode := l.first

	if currentNode == nil {
		l.first = newNode
		l.last = newNode
		l.count = 1
	} else {
		oldLastNode := l.last
		l.last = newNode
		oldLastNode.next = l.last
		l.count += 1
	}

}

func (l *List) Pop() (int, error) {
	currentNode := l.first

	if currentNode == nil {
		return -1, errors.New("cannot pop on empty list")
	}

	value := l.last.Value

	if l.count == 1 {
		l.first = nil
		l.last = nil
		l.count = 0
	} else if l.count == 2 {
		l.last = l.first
		l.count = 1
	}

	numberOfNodesTraversed := 1

	for currentNode != nil {
		currentNode = currentNode.next
		numberOfNodesTraversed += 1

		if numberOfNodesTraversed == (l.count - 1) {
			currentNode.next = nil
			l.last = currentNode
			l.count -= 1
		}
	}

	return value, nil
}

func (l *List) Array() []int {
	elements := []int{}

	currentNode := l.first

	if currentNode == nil {
		return elements
	}

	for currentNode != nil {
		elements = append(elements, currentNode.Value)
		currentNode = currentNode.next
	}

	return elements
}

func (l *List) Reverse() *List {
	panic("Please implement the Reverse function")
}
