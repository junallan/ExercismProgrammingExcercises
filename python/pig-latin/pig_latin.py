from re import match


def translate(text: str) -> str:
    if not text: return ""

    beginning_constants = get_constant_cluster(text)

    if not beginning_constants: return f"{text}ay"
    
    if len(text) >= 2 and text[1:3] == "qu":
        return f"{text.replace(text[0:3], '', 1)}{text[0:3]}ay"

    if beginning_constants:
        return f"{text.replace(beginning_constants, '', 1)}{beginning_constants}ay"


def get_constant_cluster(text: str) -> str:
    matching = match(r'^[^aeiouy]+', text)

    if matching:
        return matching.group(0)
    else:
        return ""