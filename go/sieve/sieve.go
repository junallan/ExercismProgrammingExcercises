package sieve

func Sieve(limit int) []int {
	primeFactors := []int{}

	if limit < 2 {
		return primeFactors
	} else if limit == 2 {
		primeFactors = append(primeFactors, limit)
		return primeFactors
	}

	mapNumberSequences := make(map[int]bool)

	for i := 2; i <= limit; i++ {
		mapNumberSequences[i] = true
	}

	for i := 2; i <= limit/2; i++ {
		for j := i; j <= limit/2; j++ {
			if i*j > limit {
				break
			}
			mapNumberSequences[i*j] = false
		}
	}

	for n := 2; n <= limit; n++ {
		if mapNumberSequences[n] {
			primeFactors = append(primeFactors, n)
		}
	}

	return primeFactors
}
