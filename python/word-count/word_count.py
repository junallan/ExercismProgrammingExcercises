#import re

def count_words(sentence: str) -> dict[str, int]:
    #words = re.split(r'[^\w\']+', sentence)
    words = sentence.split()
    word_counts = {}

    for w in words:
        if w in word_counts:
            word_counts[w] += 1
        else:
            word_counts[w] = 1

    return word_counts