"""Solution to Ellen's Alien Game exercise."""


class Alien:
    def __init__(self, x_coordinate: int, y_coordinate: int):
        self.x_coordinate = x_coordinate
        self.y_coordinate = y_coordinate
        self.health = 3

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
    #"""

    pass


#TODO:  create the new_aliens_collection() function below to call your Alien class with a list of coordinates.
