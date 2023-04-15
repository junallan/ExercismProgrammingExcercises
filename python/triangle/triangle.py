def equilateral(sides: list) -> bool: 
    return is_triangle(sides) and sides[0] == sides[1] == sides[2]


def isosceles(sides: list) -> bool: 
    return is_triangle(sides) and (1 <= len(set(sides)) <= 2) and is_triangle(sides)


def scalene(sides: list) -> bool:  
    return is_triangle(sides) and len(set(sides)) == 3 and is_triangle(sides)


def is_triangle(sides: list) -> bool:
    return (not 0 in sides
            and len(sides) == 3
            and (sides[0] + sides[1] >= sides[2]) 
            and (sides[0] + sides[2] >= sides[1])
            and (sides[1] + sides[2] >= sides[0]))
