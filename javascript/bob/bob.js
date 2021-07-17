export const hey = (message) => {
  if(/^[A-Z !]*$/.test(message)) {
    return 'Whoa, chill out!';
  }
  else {
    return 'Whatever.';
  }
  
};
