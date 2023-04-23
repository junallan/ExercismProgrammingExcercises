from re import match


def translate(text: str) -> str:
    if not text: return ""

    first_character = text[0]

    if first_character in "aeiou":
        return f"{text}ay"

    if (beginning_constants:= get_constant_cluster(text)):
        return f"{text.replace(beginning_constants, '', 1)}{beginning_constants}ay"

def get_constant_cluster(text: str) -> str:
    matching = match(r'^[^aeiou]+', text)

    if matching:
        return matching.group(0)
    else:
        return ""