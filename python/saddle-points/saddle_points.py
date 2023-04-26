def saddle_points(matrix: list[list[int]]) -> list[dict[str, int]]:  
    if not matrix: return []
    
    row_items_length = list(map(len, matrix))

    if not all(length == len(matrix[0]) for length in row_items_length):
        raise ValueError("irregular matrix")
    
    return [{"row": row_index + 1, "column": column_index + 1} 
            for row_index, row in enumerate(matrix) 
            for column_index in range(len(row)) 
            if max(row) == min(row[column_index] for row in matrix)]