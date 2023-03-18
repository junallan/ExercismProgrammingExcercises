package linkedlist

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
	// items := List{head: Node{value: 1}, tail: Node{value: 2}}

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
	panic("Please implement the Unshift function")
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
	panic("Please implement the Shift function")
}

func (l *List) Pop() (interface{}, error) {
	panic("Please implement the Pop function")
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
