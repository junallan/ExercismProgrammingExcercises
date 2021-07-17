export const hey = (message) => {
  if(/\?+/.test(message)) {
    return 'Sure.';
  }
  else if(/^[A-Z !]*$/.test(message)) {
    return 'Whoa, chill out!';
  }
  else {
    return 'Whatever.';
  }
  
};
