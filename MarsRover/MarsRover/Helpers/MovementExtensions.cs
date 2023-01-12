using MarsRover.Robot;

namespace MarsRover.Helpers
{
    /// <summary>
    /// Static extension methods for Movement enum
    /// </summary>
    public static class MovementExtensions
    {
        /// <summary>
        /// Parses a char to the relevant Movement 
        /// </summary>
        /// <param name="movementString"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static Movement ParseChar(char movementString) => movementString switch
        {
            'L' => Movement.Left,
            'R' => Movement.Right,
            'F' => Movement.Forward,
            _ => throw new NotImplementedException(),
        };
    }
}
