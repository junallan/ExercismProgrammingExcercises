export const hey = (message) => {
  const inputTrimmed = message.trim();
  const isQuestion = inputTrimmed.endsWith("?");
  const isYelling = inputTrimmed === inputTrimmed.toUpperCase() && inputTrimmed !== inputTrimmed.toLowerCase();
  const isSilence = inputTrimmed.length === 0;

  if(isSilence)                     return "Fine. Be that way!";
  else if(isQuestion && isYelling)  return "Calm down, I know what I'm doing!"; 
  else if(isQuestion)               return "Sure.";
  else if(isYelling)                return "Whoa, chill out!";
  else                              return "Whatever.";
};
