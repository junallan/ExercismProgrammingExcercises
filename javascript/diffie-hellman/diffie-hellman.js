export class DiffieHellman {
  
  isPrime(num) {
    for (let i = 2; i < num; i++) 
        if (num % i === 0) return false;
    return num > 1;
  }

  constructor(p, g) {
    if (!this.isPrime(p) || !this.isPrime(g))
        throw new Error('Need to enter number that is prime');

      this.p = p;
      this.g = g;
  }

  getPublicKey(privateKey) {
      if(!((1 < privateKey && privateKey < this.p) || (1 < privateKey && privateKey < this.g)))
          throw new Error('Private key entered is invalid');

      return (this.g ** privateKey) % this.p;
  }

  getSecret(theirPublicKey, myPrivateKey) {
      return (theirPublicKey ** myPrivateKey) % this.p;
  }
}
