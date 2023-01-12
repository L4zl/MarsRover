using MarsRover.Helpers;
using MarsRover.Core;

namespace MarsRover.Robot;

public class Robot
{
    public Orientation CurrentOrientation { get; private set; }
    public Position CurrentPosition { get; private set; }
    public bool Lost { get; private set; } = false;
    public List<Movement> Commands { get; private set; } = new List<Movement>();

    public Robot(Position startingPosition, Orientation startingOrientation, List<Movement> commands)
    {
        CurrentOrientation = startingOrientation;
        CurrentPosition = startingPosition;
        Commands = commands;
    }

    private void TurnLeft()
    {
        if (Lost)
            return;
        CurrentOrientation = CurrentOrientation.TurnLeft();
    }

    private void TurnRight()
    {
        if (Lost)
            return;
        CurrentOrientation = CurrentOrientation.TurnRight();
    }

    private void MoveForwards(Func<Position, bool> validate)
    {
        if (Lost)
            return;

        var newPosition = CurrentPosition.MoveForwards(CurrentOrientation);

        bool valid = validate(newPosition);

        if (!valid)
        {
           Lost = true;
            return;
        }

        CurrentPosition = newPosition;
    }


    /// <summary>
    /// Robot will run the list of commands to either completion or lost
    /// </summary>
    /// <param name="validate"></param>
    public void Run(Func<Position, bool> validate)
    {
        foreach(Movement movement in Commands)
        {
            switch (movement)
            {
                case Movement.Left: 
                    TurnLeft();
                    break;

                case Movement.Right:
                    TurnRight();
                    break;

                case Movement.Forward:
                    MoveForwards(validate);
                    break;

                default:
                    break;
            }
        }
    }
}
