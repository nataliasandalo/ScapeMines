using System;

namespace EscapeMines.Game.Strategy
{
    /// <inheritdoc />
    public class Yellow : Color
    {
        public override void ChangeColor()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
    }
}
