package binarysearch

func SearchInts(list []int, key int) int {
	for currentStartSearchIndex, currentEndSearchIndex := 0, len(list); currentStartSearchIndex != currentEndSearchIndex; {
		mid := (currentEndSearchIndex + currentStartSearchIndex) / 2
		if key == list[mid] {
			return mid
		} else if key < list[mid] {
			currentEndSearchIndex = mid
		} else {
			currentStartSearchIndex = mid + 1
		}
	}

	return -1
}
