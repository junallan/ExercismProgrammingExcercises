package secret

func Handshake(code uint) []string {
	secretCodes := []string{}
	actionCodes := []string{"wink", "double blink", "close your eyes", "jump"}

	var result uint
	var maskedCheck uint

	for codeIndex, item := range actionCodes {
		maskedCheck = 1 << uint(codeIndex)
		result = maskedCheck & code

		if result == maskedCheck {
			secretCodes = append(secretCodes, item)
		}
	}

	maskedCheck = 1 << uint(4)
	result = maskedCheck & code

	if result == maskedCheck {
		for i, j := 0, len(secretCodes)-1; i < j; i, j = i+1, j-1 {
			secretCodes[i], secretCodes[j] = secretCodes[j], secretCodes[i]
		}
	}

	return secretCodes
}
