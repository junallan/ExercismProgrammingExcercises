RAINDROPS = {3: "Pling", 5: "Plang", 7: "Plong"}


def convert(number: int) -> str:
    sounds = [sound         
        for factor, sound in RAINDROPS.items() 
        if not number % factor]

    return "".join(sounds) or str(number)


