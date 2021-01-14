using System.Collections.Generic;
using EscapeMines.Game.Models;

namespace EscapeMines.Game.ReadModels
{
    public class AdvancedSettingsModel
    {
        public Point Size { get; set; }
        public Point StartPoint { get; set; }
        public Point ExitPoint { get; set; }
        public List<Point> MinePoints { get; set; } = new List<Point>();
        public string Direction { get; set; }
    }
}
