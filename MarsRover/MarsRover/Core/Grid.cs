namespace MarsRover.Core;

public class Grid
{
    public int Width { get; private set; }
    public int Height { get; private set; }

    public Grid(int width, int height)
    {
        Width = width;
        Height = height;
    }

    /// <summary>
    /// Checks if a given position exists on the grid
    /// </summary>
    /// <param name="position"></param>
    /// <returns>bool</returns>
    public bool IsValidPosition(Position position)
    {
        if (position.X < 0 
            || position.X > Width 
            || position.Y < 0 
            || position.Y > Height)
            return false;

        return true;
    }
}
