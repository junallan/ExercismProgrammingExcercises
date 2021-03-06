export const hey = (message) => {
  let isQuestion = /\?$/.test(message.replace(/\s/g,''));
  let isYelling = /[A-Z]+/.test(message) && /^[A-Z !?,0-9%^@#$(*]*$/.test(message);
  let isSilence = /^\s*$/.test(message);

  if(isSilence)                     return "Fine. Be that way!";
  else if(isQuestion && isYelling)  return "Calm down, I know what I'm doing!"; 
  else if(isQuestion)               return "Sure.";
  else if(isYelling)                return "Whoa, chill out!";
  else                              return "Whatever.";
};
