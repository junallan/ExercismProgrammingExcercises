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
        if(instructions.Length == 0) return;

        (_direction, _x, _y) = MoveDirection(instructions[0]);

        if(instructions.Length > 1) Move(instructions.Substring(1));
    }

    private (Direction, int, int) MoveDirection(char movement) =>  movement switch
    {
        'R' when _direction == Direction.North => (Direction.East, _x, _y),
        'R' when _direction == Direction.East => (Direction.South, _x, _y),
        'R' when _direction == Direction.South => (Direction.West, _x, _y),
        'R' when _direction == Direction.West => (Direction.North, _x, _y),
        'L' when _direction == Direction.North => (Direction.West, _x, _y),
        'L' when _direction == Direction.East => (Direction.North, _x, _y),
        'L' when _direction == Direction.South => (Direction.East, _x, _y),
        'L' when _direction == Direction.West => (Direction.South, _x, _y),
        'A' when _direction == Direction.North => (_direction, _x, _y + 1),
        'A' when _direction == Direction.South => (_direction, _x, _y - 1),
        'A' when _direction == Direction.East => (_direction, _x + 1, _y),
        'A' when _direction == Direction.West => (_direction, _x - 1, _y),
        _ => (_direction, _x, _y)
    };
}