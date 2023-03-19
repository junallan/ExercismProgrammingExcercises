package secret

func Handshake(code uint) []string {
	secretCodes := []string{}
	var result uint

	for i := 0; i < 5; i++ {
		var maskedCheck uint = 1 << i
		result = maskedCheck & code

		if result == maskedCheck {
			switch i {
			case 0:
				secretCodes = append(secretCodes, "wink")
			case 1:
				secretCodes = append(secretCodes, "double blink")
			case 2:
				secretCodes = append(secretCodes, "close your eyes")
			case 3:
				secretCodes = append(secretCodes, "jump")
			case 4:
				for i, j := 0, len(secretCodes)-1; i < j; i, j = i+1, j-1 {
					secretCodes[i], secretCodes[j] = secretCodes[j], secretCodes[i]
				}
			}
		}
	}

	return secretCodes
}
