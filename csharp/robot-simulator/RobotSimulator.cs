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
        foreach (var movement in instructions) MoveDirection(movement);
    }

    private void MoveDirection(char movement)
    {
        if (movement == 'R' || movement == 'L') Turn(movement == 'R' ? 1 : -1);      
        else Advance();
    }

    private void Turn(int movement)
    {
        _direction = (Direction) (((int)_direction + movement + 4) % 4);
    }

    private void Advance()
    {
        switch(_direction)
        {
            case Direction.North: _y++; break;
            case Direction.South: _y--; break;
            case Direction.East: _x++; break;
            case Direction.West: _x--; break;
        }
    }
}