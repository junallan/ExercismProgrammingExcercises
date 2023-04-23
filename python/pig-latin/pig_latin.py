from re import match


def translate(text: str) -> str:
    if not text: return ""

    return " ".join(translate_word(word) for word in text.split())  


def translate_word(word: str) -> str:
    if word[0] == "y" and not get_constant_cluster(word[1:]): 
        return f"{word[1:]}{word[0]}ay"

    beginning_constants = get_constant_cluster(word)

    if not beginning_constants or word.startswith("xr") or word.startswith("yt"): 
        return f"{word}ay"
    
    if word.startswith("qu"):
        return f"{word[2:]}quay"
    
    if len(word) >= 3 and word[1:3] == "qu":
        return f"{word[3:]}{word[0:3]}ay"

    if beginning_constants:
        return f"{word[len(beginning_constants):]}{beginning_constants}ay"


def get_constant_cluster(text: str) -> str:
    return matching.group() if (matching:= match(r'^[^aeiouy]+', text)) else ""