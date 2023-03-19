package linkedlist

import "errors"

// Define List and Node types here.
// Note: The tests expect Node type to include an exported field with name Value to pass.
type List struct {
	first *Node
	last  *Node
}

type Node struct {
	prev  *Node
	next  *Node
	Value interface{}
}

func NewList(args ...interface{}) *List {
	list := &List{}

	for _, item := range args {
		list.Push(item)
	}

	return list
}

func (n *Node) Next() *Node {
	return n.next
}

func (n *Node) Prev() *Node {
	return n.prev
}

func (l *List) Unshift(v interface{}) {
	node := &Node{Value: v}

	if l.first == nil {
		l.first = node
		l.last = node
	} else {
		l.first.prev = node
		node.next = l.first
		l.first = node
	}
}

func (l *List) Push(v interface{}) {
	node := &Node{Value: v}

	if l.first == nil {
		l.first = node
		l.last = node
	} else {
		previousTail := l.last
		l.last = node
		previousTail.next = l.last
		l.last.prev = previousTail
	}
}

func (l *List) Shift() (interface{}, error) {
	if l.first == nil {
		return nil, errors.New("cannot shift on empty list")
	}

	value := l.first.Value

	if l.first == l.last {
		l.first = nil
		l.last = nil
	} else {
		l.first = l.first.next
		l.first.prev = nil
	}

	return value, nil
}

func (l *List) Pop() (interface{}, error) {
	if l.last == nil {
		return nil, errors.New("cannot pop on empty list")
	}

	value := l.last.Value

	if l.first == l.last {
		l.first, l.last = nil, nil
	} else {
		l.last = l.last.prev
		l.last.next = nil
	}

	return value, nil
}

func (l *List) Reverse() {
	l.first, l.last = l.last, l.first

	n := l.first

	for n != nil {
		n.next, n.prev = n.prev, n.next
		n = n.next
	}
}

func (l *List) First() *Node {
	return l.first
}

func (l *List) Last() *Node {
	return l.last
}
