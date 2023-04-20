def convert(number):
    raindrops = {3: "Pling", 5: "Plang", 7: "Plong"}
    sounds = ([raindrops[factor] 
        if not number % factor 
        else "" 
        for factor in raindrops])

    return "".join(sounds) or str(number)


