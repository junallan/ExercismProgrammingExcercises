export const hey = (message) => {
  const isQuestion = message.trimEnd().endsWith("?");
  const isYelling = /[A-Z]+/.test(message) && /^[A-Z !?,0-9%^@#$(*]*$/.test(message);
  const isSilence = message.trim().length === 0;

  if(isSilence)                     return "Fine. Be that way!";
  else if(isQuestion && isYelling)  return "Calm down, I know what I'm doing!"; 
  else if(isQuestion)               return "Sure.";
  else if(isYelling)                return "Whoa, chill out!";
  else                              return "Whatever.";
};
