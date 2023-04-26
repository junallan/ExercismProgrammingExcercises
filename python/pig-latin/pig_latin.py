from re import match


def translate(text: str) -> str:
    if not text: return ""

    return " ".join(translate_word(word) for word in text.split())  


def translate_word(word: str) -> str:
    if word[0] in "aeiou" or word.startswith("xr") or word.startswith("yt"): 
        return f"{word}ay"

    for pos in range(1, len(word)):
        if word[pos] in "aeiouy":
            pos += 1 if word[pos] == "u" and word[pos - 1] == "q" else 0    
            return f"{word[pos:]}{word[:pos]}ay"