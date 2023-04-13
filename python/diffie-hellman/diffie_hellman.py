import random

def private_key(p: int) -> int:
    random_number = random.randint(2, p-1)

    while not is_prime(random_number):
        random_number = random.randint(2, p-1)

    return random_number


def public_key(p, g, private):
    pass


def secret(p, public, private):
    pass

def is_prime(n: int) -> bool:
    if n < 2:
        return False
    
    for i in range(2, int(n ** 0.5) + 1):
        if n % i == 0:
            return False
        
    return True
