from re import match


def translate(text: str) -> str:
    if not text: return ""

    if text[0] == "y" and not get_constant_cluster(text[1:]): 
        return f"{text.replace(text[0], '')}{text[0]}ay"

    beginning_constants = get_constant_cluster(text)

    if not beginning_constants or text.startswith("xr") or text.startswith("yt"): 
        return f"{text}ay"
    
    if text.startswith("qu"):
        return f"{text.replace('qu', '')}quay"
    
    if len(text) >= 3 and text[1:3] == "qu":
        return f"{text.replace(text[0:3], '', 1)}{text[0:3]}ay"

    if beginning_constants:
        return f"{text.replace(beginning_constants, '', 1)}{beginning_constants}ay"


def get_constant_cluster(text: str) -> str:
    matching = match(r'^[^aeiouy]+', text)

    if matching:
        return matching.group(0)
    else:
        return ""