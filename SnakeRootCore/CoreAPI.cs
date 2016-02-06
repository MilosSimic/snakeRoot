using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using snakeRootlib;
using SnakeRootCore.visuals;
using LyricsCrawler;
using LyricsCrawler.assets;
using NetTester;
using TwitterMenager;
using XMLSerializer;
using SnakeRootCore.info;
using System.IO;

namespace SnakeRootCore
{
    public class CoreAPI
    {

        #region FIELDS

        protected Player player;

        #endregion

        #region CONSTRUCTOR

        public CoreAPI()
        {
            player = new Player();
        }

        #endregion

        #region HELPER_METHODS

        private bool testNet()
        {
            if (DNSTester.DnsTest())
            {
                //throw new InternetException("No connection");
                return true;
            }

            return false;
        }

        #endregion

        #region PLAYER_API

        public int playSong(String songName)
        {
            int stream = player.play(songName);
            
            return stream;
        }

        public void stop()
        {
            player.stop();
        }

        public void pause()
        {
            player.pause();
        }

        public bool init()
        {
            bool init = player.initPLayer();

            return init;
        }

        public bool isStopped()
        {
            return player.isStopped();
        }

        public void mute()
        {
            player.mute();
        }

        public void setVolume(float val)
        {
            player.setVolume(val);
        }

        public void setSpeakerPan(float side)
        {
            player.setSpeakerPan(side);
        }

        public void seekSong(double secs)
        {
            player.seekSong(secs);
        }

        public Bitmap visualisator(Visual visual, int Width, int Height,
            Color colorDown, Color colorUpper, Color background,
            int linewidth, int distance, bool liear, bool fullSpectrum, bool highQuality)
        {
            Bitmap picture = player.visualisator(ChooseVisual.choose(visual), Width, Height, colorDown, colorUpper, 
                background, linewidth, distance, liear, fullSpectrum, highQuality);

            return picture;
        }

        public Position whereIsSong()
        {
            return new Position(player.whereIsSong().PositionSong, player.whereIsSong().Current);
        }

        public int time()
        {
            return player.time();
        }

        public String songTime()
        {
            return player.songTime();
        }

        public SongInfo songInfo()
        {

            return new SongInfo(player.songInfo().FullSongTime, player.songInfo().songDuration, 
                                player.songInfo().Artist, player.songInfo().Title, player.songInfo().Img,player.songInfo().Duration);
        }

        public void freeAll()
        {
            player.freeAll();
        }

        #endregion

        #region LYRICS_API

        public String[] getLyrics(String author, String name)
        {
            if (testNet())
            {
                WebCrawler crawler = new WebCrawler();
                return crawler.getLyrics(author, name);
            }

            return null;

        }

        #endregion

        #region INFO_API

        public String getInfo(String artist)
        {
            if (testNet())
            {
                WebCrawler crawler = new WebCrawler();
                return crawler.getInfo(artist);
            }

            return null;
        }

        #endregion

        #region TWITTER_API

        public void tweet(String what)
        {
            Class1.tweet(what);
        }

        #endregion

        #region PLAYLIST_API

        public void save(List<String> list, String fileName)
        {
            PlaylistAPI.SerializePlaylist(list, fileName);
        }

        public void loadList(List<String> list, String fileName)
        {
            PlaylistAPI.DeserializePlaylist(list, fileName);
        }

        public bool validateInput(String filename)
        {
            Console.WriteLine(filename + " " + ListValidator.validateXML(filename));
            return ListValidator.validateXML(filename);
        }

        public bool validate(Stream stream)
        {
            return ListValidator.validateXML(stream);
        }

        #endregion

        #region DNSTEST

        public bool DNSTest()
        {
            return DNSTester.DnsTest();
        }

        #endregion

    }
}
