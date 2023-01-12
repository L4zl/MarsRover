using MarsRover.Core;
using MarsRover.Helpers;
using MarsRover.Robot;

namespace MarsRover;


/// <summary>
/// Service that handles generating and moving the robots on a grid based on string inputs
/// </summary>
public class MovementService
{
    /// <summary>
    /// Run the Service
    /// </summary>
    /// <param name="inputs"></param>
    /// <returns></returns>
    public List<string> Run(List<string> inputs)
    {
        var output = new List<string>();
        if (inputs.Count < 2)
            return output;

        var grid = GenerateGridFromString(inputs.First());

        var robots = new List<Robot.Robot>();

        foreach (string s in inputs.Skip(1))
        {
            robots.Add(GenerateRobotFromString(s));
        }

        foreach(var robot in robots)
        {
            robot.Run(grid.IsValidPosition);
            output.Add($"({robot.CurrentPosition.X}, {robot.CurrentPosition.Y}, {robot.CurrentOrientation.OutputString()}) {(robot.Lost ? "LOST" : string.Empty)}");
        }

        return output;
    }

    private Grid GenerateGridFromString(string input)
    {
        int x = int.Parse(input.Substring(0, 1));
        int y = int.Parse(input.Substring(2, 1));

        return new Grid(x, y);
    }

    private Robot.Robot GenerateRobotFromString(string input)
    {
        int startingX = int.Parse(input.Substring(1, 1));
        int startingY = int.Parse(input.Substring(4, 1));
        Position startingPosition = new Position(startingX, startingY);

        Orientation startingOrientation = OrientationExtensions.ParseString(input.Substring(7, 1));

        string commandsString = input.Substring(10).Trim();
        List<Movement> commands = new List<Movement>();
        foreach(char c in commandsString)
        {
            commands.Add(MovementExtensions.ParseChar(c));
        }

        return new Robot.Robot(startingPosition, startingOrientation, commands);
    }
}
