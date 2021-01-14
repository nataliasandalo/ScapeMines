using System.Drawing;
using Xunit;

namespace EscapeMines.Domain.Test.Game
{
    public class PointTest
    {
        [Fact]
        public void TestPoint()
        {
            var point = new Point(10, 5);
            Assert.Equal(5, point.Y);
        }
    }
}
