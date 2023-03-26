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

var list List

func New(elements []int) *List {
	list := &List{}
	for _, item := range elements {
		list.Push(item)
	}

	return list
}

func (l *List) Size() int {
	return list.count
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
	currentNode := list.first

	if currentNode == nil {
		list.first = newNode
		list.last = newNode
		list.count = 1
	} else {
		oldLastNode := list.last
		list.last = newNode
		oldLastNode.next = list.last
		list.count += 1
	}

}

func (l *List) Pop() (int, error) {
	currentNode := list.first

	if currentNode == nil {
		return -1, errors.New("cannot pop on empty list")
	}

	currentNodeNext := list.first.next

	for currentNodeNext != nil {
		currentNode = currentNodeNext
		currentNodeNext = currentNode.next
	}

	lastValue := currentNode.Value
	list.count -= 1
	currentNode = nil

	return lastValue, nil
}

func (l *List) Array() []int {
	panic("Please implement the Array function")
}

func (l *List) Reverse() *List {
	panic("Please implement the Reverse function")
}
