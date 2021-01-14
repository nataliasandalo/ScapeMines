using EscapeMines.Game.Models;
using Xunit;

namespace EscapeMines.Domain.Test.Game
{
    public class TurtleTest
    {
        [Fact]
        public void TestTurtle()
        {
            var turtle = EscapeMines.Game.Models.Turtle.Instance(new Point(5, 6));
            var positionX = turtle.Position.X;
            var positionY = turtle.Position.Y;
            Assert.Equal(positionX, 5);
            Assert.Equal(positionY, 6);
        }
    }
}
