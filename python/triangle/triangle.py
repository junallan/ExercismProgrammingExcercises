def equilateral(sides: list) -> bool: 
    return not has_0_side(sides) and sides[0] == sides[1] == sides[2]


def isosceles(sides: list) -> bool: 
    return not has_0_side(sides) and (1 <= len(set(sides)) <= 2) and is_triangle(sides)


def scalene(sides: list) -> bool:  
    return not has_0_side(sides) and len(set(sides)) == 3 and is_triangle(sides)
    

def has_0_side(sides: list) -> bool:
    return 0 in sides


def is_triangle(sides: list) -> bool:
    return ((sides[0] + sides[1] >= sides[2]) 
            and (sides[0] + sides[2] >= sides[1])
            and (sides[1] + sides[2] >= sides[0]))
