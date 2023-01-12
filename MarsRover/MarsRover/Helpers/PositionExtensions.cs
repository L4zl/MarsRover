using MarsRover.Core;
using MarsRover.Robot;

namespace MarsRover.Helpers;

/// <summary>
/// Static extension methods for Position class
/// </summary>
public static class PositionExtensions
{

    /// <summary>
    /// Given a position and orientation return a new position after moving forwards
    /// </summary>
    /// <param name="position"></param>
    /// <param name="orientation"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static Position MoveForwards(this Position position, Orientation orientation) => orientation switch
    {
        Orientation.North => new Position(position.X, position.Y + 1),
        Orientation.East => new Position(position.X + 1, position.Y),
        Orientation.South => new Position(position.X, position.Y - 1),
        Orientation.West => new Position(position.X - 1, position.Y),
        _ => throw new NotImplementedException(),
    };
}
