﻿namespace EscapeMines.Game.Models
{
    public enum Directions
    {
        North,
        South,
        East,
        West
    }

    public enum State
    {
        IsDead,
        Normal,
        IsOutOfBounds,
        IsExit,
        IsDanger
    }
}
