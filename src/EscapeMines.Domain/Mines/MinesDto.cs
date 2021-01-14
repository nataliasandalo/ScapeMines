using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Domain.Mines
{
    public class MinesDto
    {
        public int BoardId { get; set; }
        public int Columns { get; set; }
        public int Rows { get; set; }
    }
}
