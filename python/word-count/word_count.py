import re
import string

def count_words(sentence: str) -> dict[str, int]:
    word_counts = {}
    delimeters = string.punctuation.replace("'", "") + "\n\t "
    words = [w.strip(string.punctuation).lower() for w in re.split(f"[{delimeters}]+", sentence) if not w.isspace() and w]
#    print("words " + words)
    for w in words:
        if w in word_counts:
            word_counts[w] += 1
        else:
            word_counts[w] = 1

    return word_counts

    # translator = str.maketrans("", "", string.punctuation)
    # words = sentence.translate(translator).lower().split()
    # word_counts = {}

    # for w in words:
    #     if w in word_counts:
    #         word_counts[w] += 1
    #     else:
    #         word_counts[w] = 1

    # return word_counts