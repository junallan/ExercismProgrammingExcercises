def saddle_points(matrix: list[list[int]]) -> list[dict[str, int]]:
    if len(matrix) == 0: return []

    row_items_length = map(len, matrix)

    if not all(length == len(matrix[0]) for length in row_items_length):
        raise ValueError("irregular matrix")