def saddle_points(matrix: list[list[int]]) -> list[dict[str, int]]:  
    if not matrix: return []
    
    row_items_length = list(map(len, matrix))

    if not all(length == len(matrix[0]) for length in row_items_length):
        raise ValueError("irregular matrix")
    
    matching_saddle_points = []

    for row_index, row in enumerate(matrix):
        max_row = max(row)
        
        for column_index in range(len(row)):
            min_column = min(row[column_index] for row in matrix)   
        
            if max_row == min_column:
                matching_saddle_points.append({"row": row_index + 1, "column": column_index + 1})

    return matching_saddle_points