def translate(text: str) -> str:
    if not text: return ""

    first_character = text[0]

    if first_character in "aeiou":
        return f"{text}ay"
    
