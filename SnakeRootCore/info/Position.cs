using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeRootCore.info
{
    public class Position
    {
        public int PositionSong { get; set; }
        public String Current { get; set; }

        public Position(int position, String current)
        {
            PositionSong = position;
            Current = current;
        }
    }
}
