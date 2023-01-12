using MarsRover.Robot;

namespace MarsRover.Helpers;

/// <summary>
/// Static extension methods for Orientation enum
/// </summary>
public static class OrientationExtensions
{
    /// <summary>
    /// Given an Orientation return the Orientation 90 degrees to the left of it
    /// </summary>
    /// <param name="orientation"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static Orientation TurnLeft(this Orientation orientation) => orientation switch
    {
        Orientation.North => Orientation.West,
        Orientation.East => Orientation.North,
        Orientation.South => Orientation.East,
        Orientation.West => Orientation.South,
        _ => throw new NotImplementedException(),
    };

    /// <summary>
    /// Given an Orientation return the Orientation 90 degrees to the right of it
    /// </summary>
    /// <param name="orientation"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static Orientation TurnRight(this Orientation orientation) => orientation switch
    {
        Orientation.North => Orientation.East,
        Orientation.East => Orientation.South,
        Orientation.South => Orientation.West,
        Orientation.West => Orientation.North,
        _ => throw new NotImplementedException(),
    };

    /// <summary>
    /// Parses a string to the relevant Orientation 
    /// </summary>
    /// <param name="orientationString"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static Orientation ParseString(string orientationString) => orientationString switch
    {
        "N" => Orientation.North,
        "E" => Orientation.East,
        "S" => Orientation.South,
        "W" => Orientation.West,
        _ => throw new NotImplementedException(),
    };

    /// <summary>
    /// Given an orientation return the relevant letter string for output
    /// </summary>
    /// <param name="orientation"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static string OutputString(this Orientation orientation) => orientation switch
    {
        Orientation.North => "N",
        Orientation.East => "E",
        Orientation.South => "S",
        Orientation.West => "W",
        _ => throw new NotImplementedException(),
    };
}
