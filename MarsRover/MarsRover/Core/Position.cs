﻿namespace MarsRover.Core;

public class Position
{
    public int X { get; init; }
    public int Y { get; init; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
}
