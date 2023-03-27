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

func New(elements []int) *List {
	l := &List{}
	for _, item := range elements {
		l.Push(item)
	}

	return l
}

func (l *List) Size() int {
	return l.count
}

func (l *List) Push(element int) {
	newNode := &Node{Value: element}
	currentNode := l.first

	l.count += 1

	if currentNode == nil {
		l.first, l.last = newNode, newNode
	} else {
		oldLastNode := l.last
		l.last = newNode
		oldLastNode.next = l.last
	}
}

func (l *List) Pop() (int, error) {
	currentNode := l.first

	if currentNode == nil {
		return -1, errors.New("cannot pop on empty list")
	}

	value := l.last.Value

	numberOfNodesTraversed := 0

	for currentNode != nil {

		numberOfNodesTraversed += 1

		if numberOfNodesTraversed == (l.count - 1) {
			currentNode.next = nil
			l.last = currentNode
		}

		currentNode = currentNode.next
	}

	l.count -= 1

	return value, nil
}

func (l *List) Array() []int {
	elements := []int{}

	currentNode := l.first

	for currentNode != nil {
		elements = append(elements, currentNode.Value)
		currentNode = currentNode.next
	}

	return elements
}

func (l *List) Reverse() *List {
	reversedList := &List{}
	elements := l.Array()

	indexOfLastNode := len(elements) - 1

	for index := indexOfLastNode; 0 <= index; index-- {
		reversedList.Push(elements[index])
	}

	return reversedList
}
