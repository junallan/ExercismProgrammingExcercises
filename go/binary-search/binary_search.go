package binarysearch

func SearchInts(list []int, key int) int {
	listLength := len(list)

	if listLength == 1 {
		return 0
	}

	currentStartSearchIndex := listLength / 2
	currentEndSearchIndex := listLength - 1

	for currentStartSearchIndex <= currentEndSearchIndex {
		if key == list[currentStartSearchIndex] {
			return currentStartSearchIndex
		} else if key < list[currentStartSearchIndex] {
			currentEndSearchIndex = currentStartSearchIndex - 1
			currentStartSearchIndex /= 2
		} else {
			middleOfTopHalfIndexSpot := (currentEndSearchIndex - currentStartSearchIndex) / 2

			if middleOfTopHalfIndexSpot == 0 {
				middleOfTopHalfIndexSpot++
			}
			currentStartSearchIndex += middleOfTopHalfIndexSpot
		}
	}

	return -1
}
