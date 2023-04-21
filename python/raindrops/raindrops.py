RAINDROPS = {3: "Pling", 5: "Plang", 7: "Plong"}

def convert(number: int) -> str:
    sounds = ([RAINDROPS[factor]          
        for factor in RAINDROPS if not number % factor])

    return "".join(sounds) or str(number)


