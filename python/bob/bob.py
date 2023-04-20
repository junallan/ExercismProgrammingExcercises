def response(hey_bob: str) -> str:
    is_yelling = hey_bob.isupper()
    is_asking_a_question = hey_bob.endswith("?")
    if is_yelling and is_asking_a_question:
        return "Calm down, I know what I'm doing!"
    elif is_yelling:
        return "Whoa, chill out!"
    elif is_asking_a_question:
        return "Sure."
    pass
