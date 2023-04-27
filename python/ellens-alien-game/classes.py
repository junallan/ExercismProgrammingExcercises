"""Solution to Ellen's Alien Game exercise."""
from typing import List


class Alien:
    """
    Represents an alien object in Ellen's Alien Game.

    Attributes:
        x_coordinate (int): The x-coordinate of the alien's current position.
        y_coordinate (int): The y-coordinate of the alien's current position.
        health (int): The current health of the alien.
    """
    total_aliens_created = 0

    def __init__(self, x_coordinate: int, y_coordinate: int):
        self.x_coordinate = x_coordinate
        self.y_coordinate = y_coordinate
        self.health = 3
        Alien.total_aliens_created += 1


    # hit(): Decrement Alien health by one point.
    def hit(self):
        self.health -= 1


    # is_alive(): Return a boolean for if Alien is alive (if health is > 0).
    def is_alive(self) -> bool:
        return self.health > 0


    # teleport(new_x_coordinate, new_y_coordinate): Move Alien object to new coordinates.
    def teleport(self, x_coordinate: int, y_coordinate: int):
        self.x_coordinate = x_coordinate
        self.y_coordinate = y_coordinate


    # collision_detection(other): Implementation TBD.
    def collision_detection(self, other):
        pass



def new_aliens_collection(coordinates: List[tuple[int,int]]) -> List[Alien]:
    return [Alien(coord[0], coord[1]) for coord in coordinates]
