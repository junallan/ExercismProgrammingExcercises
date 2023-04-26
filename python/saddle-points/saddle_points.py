def saddle_points(matrix: list[list[int]]) -> list[dict[str, int]]:  
    if not matrix: return []
    
    number_of_rows = len(matrix)
    row_items_length = list(map(len, matrix))

    if not all(length == len(matrix[0]) for length in row_items_length):
        raise ValueError("irregular matrix")
    
    matching_saddle_points = []

    for row_index in range(number_of_rows):
        max_columns = indexes_of(matrix[row_index], max(matrix[row_index]))

        for column_index in max_columns:
            column = [matrix[row][column_index] for row in range(number_of_rows)]    

            min_rows = indexes_of(column, min(column))

            if row_index in min_rows and column_index in max_columns:
                matching_saddle_points.append({"row": row_index + 1, "column": column_index + 1})

    return matching_saddle_points


def indexes_of(elements: list[int], value_to_match: int) -> list[int]:
    return [index for index, value in enumerate(elements) if value == value_to_match]