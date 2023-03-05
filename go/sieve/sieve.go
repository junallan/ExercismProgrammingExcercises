package sieve

func Sieve(limit int) []int {
	if limit < 2 {
		return []int{}
	} else if limit == 2 {
		return []int{2}
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

	primeFactors := []int{}

	for n := 2; n <= limit; n++ {
		if mapNumberSequences[n] {
			primeFactors = append(primeFactors, n)
		}
	}

	return primeFactors
}
