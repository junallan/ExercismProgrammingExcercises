// @ts-check

const HUMIDITY_THRESHOLD_PERCENTAGE = 70;
const TEMPERATURE_OVERHEATING_THRESHOLD = 500;
const TEMPERATURE_OVERHEATING_SHUTDOWN_THRESHOLD = 600;

export class ArgumentError extends Error {}

export class OverheatingError extends Error {
  constructor(temperature) {
    super(`The temperature is ${temperature} ! Overheating !`);
    this.temperature = temperature;
  }
}

//function check(fn) {
//    if (fn === undefined) return;

//}

/**
 * Check if the humidity level is not too high.
 *
 * @param {number} humidityPercentage
 * @throws {Error}
 */
export function checkHumidityLevel(humidityPercentage) {
    if(humidityPercentage > HUMIDITY_THRESHOLD_PERCENTAGE) throw new Error('Humidity max level has been reached');
}

/**
 * Check if the temperature is not too high.
 *
 * @param {number|null} temperature
 * @throws {ArgumentError|OverheatingError}
 */
export function reportOverheating(temperature) {
    if (temperature === null)
        throw new ArgumentError('Temperature was not specified, therefore overheating cannot be determined');
    else if (temperature > TEMPERATURE_OVERHEATING_THRESHOLD) 
        throw new OverheatingError(temperature);
  
}

/**
 *  Triggers the needed action depending on the result of the machine check.
 *
 * @param {{
 * check: function,
 * alertDeadSensor: function,
 * alertOverheating: function,
 * shutdown: function
 * }} actions
 * @throws {ArgumentError|OverheatingError|Error}
 */
export function monitorTheMachine(actions) {
    try {
        actions.check();
    } catch (error) {
        if (error instanceof ArgumentError)
            actions.alertDeadSensor();
        else if (error instanceof OverheatingError) {
            if (error.temperature > TEMPERATURE_OVERHEATING_SHUTDOWN_THRESHOLD)
                actions.shutdown();
            else
                actions.alertOverheating();
        }
    }
}
