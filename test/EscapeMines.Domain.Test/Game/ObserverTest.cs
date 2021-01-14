using EscapeMines.Game;
using EscapeMines.Game.Models;
using Xunit;

namespace EscapeMines.Domain.Test.Game
{
    public class ObserverTest
    {
        [Fact]
        public void TestObserver()
        {
            var observer = new Observer(new Grid(10, 6));
            Assert.Equal(false, observer.IsDanger(new Point(5, 5)));
        }
    }
}
