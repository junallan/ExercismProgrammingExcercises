let TotalHours = 24;
let TotalMinutes = 60;

export class Clock {
    constructor(hour, minutes) {
        let overlapHour = hour;
        let overlapMinutes = 0;

        if (minutes < 0) {
            let tempMinutes = minutes;

            do {
                overlapMinutes = TotalMinutes + tempMinutes;
                tempMinutes = overlapMinutes;
                overlapHour -= 1;
                //console.log('overlapHour: ' + overlapHour);
            } while (overlapMinutes < 0)
        } else {
           // console.log('minutes: ' + minutes);
            overlapMinutes = minutes === undefined ? 0 : minutes % TotalMinutes;
          //  console.log('overlapMinutes: ' + overlapMinutes);
        }

        if (overlapHour < 0) {
            let tempHour = overlapHour;

            do {
                overlapHour = TotalHours + tempHour;
                tempHour = overlapHour;
            } while (overlapHour < 0)     
            
        } else {
            overlapHour = overlapHour % TotalHours;
        }  

        if (minutes !== undefined && minutes >= 0) {
            overlapHour = (overlapHour + parseInt(minutes / TotalMinutes)) % TotalHours;
       
        }

        this._hour = overlapHour < 10 ? ['0', overlapHour.toString()].join('') : overlapHour.toString();
        this._minutes = overlapMinutes < 10 ? ['0', overlapMinutes.toString()].join('') : overlapMinutes.toString();
  }

  toString() {
      return [this._hour,this._minutes].join(':');
  }

  plus(minutes) {
      if (minutes === 0) { return this; }

      let currentMinutesParsed = parseInt(this._minutes);
      currentMinutesParsed += minutes;

      return new Clock(parseInt(this._hour), currentMinutesParsed);
  }
    
  minus(minutes) {
      if (minutes === 0) { return this; }

      let currentMinutesParsed = parseInt(this._minutes);
      currentMinutesParsed -= minutes;

      return new Clock(parseInt(this._hour), currentMinutesParsed);
  }

  equals(clock) {
      return this.toString() === clock.toString(); 
  }
}
