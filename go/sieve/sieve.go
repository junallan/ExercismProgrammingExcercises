package sieve

func Sieve(limit int) []int {
	if limit < 2 {
		return []int{}
	} else if limit == 2 {
		return []int{2}
	}

	mapNumberSequences := make([]bool, limit-1)

	for i := 0; i < limit-1; i++ {
		mapNumberSequences[i] = true
	}

	for i := 2; i <= limit/2; i++ {
		for j := 2; j <= limit/2; j++ {
			if i*j > limit {
				break
			}
			mapNumberSequences[i*j-2] = false
		}
	}

	primeFactors := []int{}

	for n := 0; n < limit-1; n++ {
		if mapNumberSequences[n] {
			primeFactors = append(primeFactors, n+2)
		}
	}

	return primeFactors
}
