def equilateral(sides: list) -> bool:
    if 0 in sides:
        return False
    
    return sides[0] == sides[1] == sides[2]


def isosceles(sides: list) -> bool:
    if 0 in sides:
        return False
    
    distinct_side_count = len(set(sides))

    return (1 <= distinct_side_count <= 2) and is_triangle(sides)


def scalene(sides: list) -> bool:
    pass

def is_triangle(sides: list) -> bool:
    return (two_sides_greater_than_one(sides[0], sides[1], sides[2]) 
            and two_sides_greater_than_one(sides[0], sides[2], sides[1])
            and two_sides_greater_than_one(sides[1], sides[2], sides[0]))

def two_sides_greater_than_one(side1: int | float, side2: int | float, side3: int | float ) -> bool:
    return side1 + side2 >= side3
