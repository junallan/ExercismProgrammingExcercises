def transform(legacy_data: dict[int, list[str]]) -> dict[str, int]:
    return {element.lower(): key 
            for key, values in legacy_data.items() 
            for element in values}
 

