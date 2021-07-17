export const hey = (message) => {
  let isQuestion = /\?+/.test(message);
  let isYelling = /[A-Z]+/.test(message) && /^[A-Z !?,0-9%^@#$(*]*$/.test(message);

  if(isQuestion && isYelling){
    return "Calm down, I know what I'm doing!";
  }
  else if(isQuestion) {
    return "Sure.";
  }
  else if(isYelling) {
    return "Whoa, chill out!";
  }
  else {
    return "Whatever.";
  }
  
};
