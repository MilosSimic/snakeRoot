using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass.AddOn.Tags;
using System.Drawing;

namespace snakeRootlib.info
{
    public class SongInfo
    {
        public String FullSongTime { get; set; }
        public int songDuration { get; set; }
        public String Artist { get; set; }
        public String Title { get; set; }
        public Image Img { get; set; }
        public double Duration { get; set; }
    }
}
