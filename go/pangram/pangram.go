package pangram

import (
	"sort"
	"strings"
)

func IsPangram(input string) bool {
	parsedInputToSortedOrder := strings.Split(strings.ToLower(input), "")

	alphabet := "abcdefghijklmnopqrstuvwxyz"
	lettersInAlphabet := len(alphabet)

	if lettersInAlphabet > len(parsedInputToSortedOrder) {
		return false
	}

	sort.Strings(parsedInputToSortedOrder)

	distinctCharacterCount := 0
	lastCharacter := ""

	for i := 0; i < len(parsedInputToSortedOrder); i++ {
		if (parsedInputToSortedOrder[i] != lastCharacter) && (strings.Contains(alphabet, parsedInputToSortedOrder[i])) {
			lastCharacter = parsedInputToSortedOrder[i]
			distinctCharacterCount += 1
		}
	}

	return lettersInAlphabet == distinctCharacterCount
}
