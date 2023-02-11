using System;

public enum Direction
{
    North,
    East,
    South,
    West
}

public class RobotSimulator
{
    private Direction _direction;
    private int _x;
    private int _y;

    public RobotSimulator(Direction direction, int x, int y)
    {
        _direction = direction;
        _x = x;
        _y = y;
    }

    public Direction Direction
    {
        get
        {
            return _direction;
        }
    }

    public int X
    {
        get
        {
            return _x;
        }
    }

    public int Y
    {
        get
        {
            return _y;
        }
    }

    public void Move(string instructions)
    {
        if(instructions.Equals("R") || instructions.Equals("L"))
        {
            _direction = instructions switch {
                "R" when _direction == Direction.North =>  Direction.East,
                "R" when _direction == Direction.East =>  Direction.South,
                "R" when _direction == Direction.South =>  Direction.West,
                "R" when _direction == Direction.West =>  Direction.North,
                "L" when _direction == Direction.North =>  Direction.West,
                "L" when _direction == Direction.East =>  Direction.North,
                "L" when _direction == Direction.South =>  Direction.East,
                "L" when _direction == Direction.West =>  Direction.South,
                _ => _direction
            };
        }
        else
        {
            switch (_direction)
            {
                case Direction.North:
                    _y += 1;    
                    break;
                case Direction.South:
                    _y -= 1;
                    break;
                case Direction.East:
                    _x += 1;
                    break;
                case Direction.West:
                    _x -= 1;
                    break;
            }
        }
    }
}