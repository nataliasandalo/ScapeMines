using System;

namespace EscapeMines.Game.Strategy
{
    public class Green : Color
    {
        public override void ChangeColor()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
