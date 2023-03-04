// Package weather determines whether condition for a given location.
package weather

// CurrentCondition is the weather condition for a given city.
var CurrentCondition string 

// CurrentLocation is the city that we are determining the weather forecast for.
var CurrentLocation string 

// Forecast determines a weather forecast based on city and condition. 
func Forecast(city, condition string) string {
	CurrentLocation, CurrentCondition = city, condition
	return CurrentLocation + " - current weather condition: " + CurrentCondition
}
