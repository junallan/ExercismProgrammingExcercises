def equilateral(sides: list) -> bool:
    if has_0_side(sides):
        return False
    
    return sides[0] == sides[1] == sides[2]


def isosceles(sides: list) -> bool:
    if has_0_side(sides):
        return False
    
    return (1 <= len(set(sides)) <= 2) and is_triangle(sides)


def scalene(sides: list) -> bool:
    if has_0_side(sides):
        return False
    
    return len(set(sides)) == 3 and is_triangle(sides)
    

def has_0_side(sides: list) -> bool:
    return 0 in sides


def is_triangle(sides: list) -> bool:
    return (two_sides_greater_than_one(sides[0], sides[1], sides[2]) 
            and two_sides_greater_than_one(sides[0], sides[2], sides[1])
            and two_sides_greater_than_one(sides[1], sides[2], sides[0]))


def two_sides_greater_than_one(
        side1: int | float, 
        side2: int | float, 
        side3: int | float ) -> bool:
    return side1 + side2 >= side3
