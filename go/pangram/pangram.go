package pangram

import (
	"sort"
	"strings"
)

func IsPangram(input string) bool {
	alphabet := "abcdefghijklmnopqrstuvwxyz"
	inputLower := strings.ToLower(input)

	for _, char := range alphabet {
		if !strings.ContainsRune(inputLower, char) {
			return false
		}
	}

	return true
}

func IsPangramSortAndCountLettersVariation(input string) bool {
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
