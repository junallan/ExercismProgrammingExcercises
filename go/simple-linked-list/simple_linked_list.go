package linkedlist

type List struct {
	first *Node
}

type Node struct {
	next  *Node
	Value interface{}
}

var list List

func New(elements []int) *List {
	list := &List{}

	return list
}

func (l *List) Size() int {
	if l.first == nil {
		return 0
	} else {
		return -1
	}
}

func (l *List) Push(element int) {
	if list.first == nil {
		list.first = &Node{Value: element}
	} else {
		currentNode := list.first
		currentNodeNext := list.first.next

		for currentNodeNext != nil {
			currentNode = currentNodeNext
			currentNodeNext = currentNode.next
		}

		currentNodeNext = &Node{Value: element}
		currentNode.next = currentNodeNext
	}

}

func (l *List) Pop() (int, error) {
	panic("Please implement the Pop function")
}

func (l *List) Array() []int {
	panic("Please implement the Array function")
}

func (l *List) Reverse() *List {
	panic("Please implement the Reverse function")
}
