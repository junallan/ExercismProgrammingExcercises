package secret

func Handshake(code uint) []string {
	const (
		ReverseCode = 4
	)

	secretCodes := []string{}

	var result uint
	var maskedCheck uint

	maskedCheck = 1 << uint(ReverseCode)
	result = maskedCheck & code
	isReverseCodes := result == maskedCheck

	actionCodes := []string{"wink", "double blink", "close your eyes", "jump"}

	codeLastIndex := len(actionCodes) - 1

	for codeIndex := 0; codeIndex <= codeLastIndex; codeIndex++ {
		var index int

		if isReverseCodes {
			index = codeLastIndex - codeIndex
		} else {
			index = codeIndex
		}

		maskedCheck = 1 << uint(index)

		result = maskedCheck & code

		if result == maskedCheck {
			secretCodes = append(secretCodes, actionCodes[index])
		}
	}

	return secretCodes
}
