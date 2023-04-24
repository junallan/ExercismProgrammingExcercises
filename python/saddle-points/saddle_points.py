import sys


def saddle_points(matrix: list[list[int]]) -> list[dict[str, int]]:
    number_of_rows = len(matrix)

    if number_of_rows == 0: return []

    row_items_length = list(map(len, matrix))

    if not all(length == len(matrix[0]) for length in row_items_length):
        raise ValueError("irregular matrix")
    
    matching_saddle_points = []

    for row_index in range(number_of_rows):
        max_columns = max_column_indexes(matrix[row_index])

        for column_index in max_columns:
            column = [matrix[row][column_index] for row in range(number_of_rows)]    

            min_rows = min_row_indexes(column)

            if row_index in min_rows and column_index in max_columns:
                matching_saddle_points.append({"row": row_index + 1, "column": column_index + 1})

    return matching_saddle_points


def max_column_indexes(row: list[int]) -> list[int]:
    current_max_value = max(row)
    indexes_of_max_columns = [i for i, value in enumerate(row) if value == current_max_value]
    return indexes_of_max_columns    


def min_row_indexes(column: list[int]) -> list[int]:
    current_min_value = min(column)
    indexes_of_min_rows = [i for i, value in enumerate(column) if value == current_min_value]
    return indexes_of_min_rows    