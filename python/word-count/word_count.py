import re
from collections import Counter


def count_words(sentence: str) -> dict[str, int]:
    words = re.findall("[a-z0-9]+(?:'[a-z]+)?", sentence.lower())
    word_counts = Counter(words)

    return {item: count for item, count in word_counts.most_common()}