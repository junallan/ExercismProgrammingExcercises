export const hey = (message) => {
  let questionTest = /\?+/.test(message);
  let yellingTest = /^[A-Z !]*$/.test(message);

  if(questionTest) {
    return 'Sure.';
  }
  else if(yellingTest) {
    return 'Whoa, chill out!';
  }
  else {
    return 'Whatever.';
  }
  
};
