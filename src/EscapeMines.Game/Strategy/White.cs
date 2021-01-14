using System;

namespace EscapeMines.Game.Strategy
{
    public class White : Color
    {
        public override void ChangeColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
