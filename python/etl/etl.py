def transform(legacy_data: dict[int, list[str]]) -> dict[str, int]:
    transformed_data = {}
    for item in legacy_data:
        for element in legacy_data[item]:
            transformed_data[element.lower()] = item

    return transformed_data        
    #return {legacy_data[item]: item for item in legacy_data}

