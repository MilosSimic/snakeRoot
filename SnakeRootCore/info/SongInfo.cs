using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SnakeRootCore.info
{
    public class SongInfo
    {
        public String Artist { get; set; }
        public String FullSongTime { get; set; }
        public int songDuration { get; set; }
        public String Title { get; set; }
        public Image Img { get; set; }
        public double Duration { get; set; }

        public SongInfo(String fullSongTime, int durationSong, String artist,String title,Image img,double duration)
        {
            Artist = artist;
            FullSongTime = fullSongTime;
            songDuration = durationSong;
            Title = title;
            Img = img;
            Duration = duration;
        }
    }
}
