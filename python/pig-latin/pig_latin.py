from re import match


def translate(text: str) -> str:
    if not text: return ""

    return " ".join(translate_word(word) for word in text.split())  


def translate_word(word: str) -> str:
    if word[0] == "y" and not get_constant_cluster(word[1:]): 
        return f"{word.replace(word[0], '')}{word[0]}ay"

    beginning_constants = get_constant_cluster(word)

    if not beginning_constants or word.startswith("xr") or word.startswith("yt"): 
        return f"{word}ay"
    
    if word.startswith("qu"):
        return f"{word.replace('qu', '')}quay"
    
    if len(word) >= 3 and word[1:3] == "qu":
        return f"{word.replace(word[0:3], '', 1)}{word[0:3]}ay"

    if beginning_constants:
        return f"{word.replace(beginning_constants, '', 1)}{beginning_constants}ay"


def get_constant_cluster(text: str) -> str:
    return matching.group() if (matching:= match(r'^[^aeiouy]+', text)) else ""