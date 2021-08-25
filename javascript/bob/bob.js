export const hey = (message) => {
  const isQuestion = message.trimEnd().endsWith("?");
  const isYelling = message === message.toUpperCase() && message !== message.toLowerCase();
  const isSilence = message.trim().length === 0;

  if(isSilence)                     return "Fine. Be that way!";
  else if(isQuestion && isYelling)  return "Calm down, I know what I'm doing!"; 
  else if(isQuestion)               return "Sure.";
  else if(isYelling)                return "Whoa, chill out!";
  else                              return "Whatever.";
};
