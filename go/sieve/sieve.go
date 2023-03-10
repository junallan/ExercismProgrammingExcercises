package sieve

func Sieve(limit int) []int {
	if limit < 2 {
		return []int{}
	} else if limit == 2 {
		return []int{2}
	}

	mapNumberSequences := make([]bool, limit+1)
	primes := make([]int, limit/2)
	primeIndex := 0

	for number := 2; number <= limit; number++ {
		if !mapNumberSequences[number] {
			primes[primeIndex] = number
			primeIndex++

			for i := number + number; i <= limit; i += number {
				mapNumberSequences[i] = true
			}
		}

	}

	return primes[:primeIndex]
}
