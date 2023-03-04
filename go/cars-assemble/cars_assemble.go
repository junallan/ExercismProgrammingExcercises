package cars

const (
	NumberOfMinutesInHour   = 60
	CarCountForGroupPackage = 10
	PackageCarCost          = 9_5000
	IndividualCarCost       = 10_000
)

// CalculateWorkingCarsPerHour calculates how many working cars are
// produced by the assembly line every hour.
func CalculateWorkingCarsPerHour(productionRate int, successRate float64) float64 {
	return float64(productionRate) * (successRate / float64(100))
}

// CalculateWorkingCarsPerMinute calculates how many working cars are
// produced by the assembly line every minute.
func CalculateWorkingCarsPerMinute(productionRate int, successRate float64) int {
	return int(CalculateWorkingCarsPerHour(productionRate, successRate) / NumberOfMinutesInHour)
}

// CalculateCost works out the cost of producing the given number of cars.
func CalculateCost(carsCount int) uint {
	groupPackageCount := uint(carsCount / CarCountForGroupPackage)
	individualCarCount := uint(carsCount % CarCountForGroupPackage)

	return uint(groupPackageCount)*PackageCarCost + (individualCarCount * IndividualCarCost)
}
