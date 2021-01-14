using System.Drawing;
using EscapeMines.Game;
using Xunit;

namespace EscapeMines.Domain.Test.Game
{
    public class PrinterTest
    {
        [Fact]
        public void TestPrinter()
        {
            Assert.NotEqual(Printer.Success, Printer.Dead);
        }
    }
}
