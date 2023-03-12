package pangram

import (
	"sort"
	"strings"
)

func IsPangram(input string) bool {
	const alphabetMask int = 0b11111111111111111111111111
	inputMask := 0
	length := len(input)

	for i := 0; i < length; i++ {
		asciiChar := input[i]

		if 65 <= asciiChar && asciiChar <= 90 {
			inputMask |= 1 << (asciiChar - 65)
		} else if 97 <= asciiChar && asciiChar <= 122 {
			inputMask |= 1 << (asciiChar - 97)
		}
	}

	return alphabetMask == inputMask
}

// func IsPangramStringRuneComparisonVariation(input string) bool {
// 	alphabet := "abcdefghijklmnopqrstuvwxyz"
// 	inputLower := strings.ToLower(input)

// 	for _, char := range alphabet {
// 		if !strings.ContainsRune(inputLower, char) {
// 			return false
// 		}
// 	}

// 	return true
// }

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
