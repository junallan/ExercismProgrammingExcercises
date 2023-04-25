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
    
    if beginning_constants:
        length_beginning_constants = len(beginning_constants)
        word_split_index = length_beginning_constants
        if word[length_beginning_constants] == "u" and word[length_beginning_constants-1] == "q":
            word_split_index += 1
    
        return f"{word[word_split_index:]}{word[:word_split_index]}ay"


def get_constant_cluster(text: str) -> str:
    return matching.group() if (matching:= match(r'^[^aeiouy]+', text)) else ""