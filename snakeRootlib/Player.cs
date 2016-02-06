using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass;
using snakeRootlib.visuals;
using System.Drawing;
using Un4seen.Bass.AddOn.Tags;
using snakeRootlib.info;
using System.Xml;
using Security.cs;
using Un4seen.Bass.AddOn.Fx;
using snakeRootlib.flow;

namespace snakeRootlib
{
    public class Player
    {

        #region attributes

        protected int Stream { get; set; }
        protected bool IsInit { get; set; }
        protected int StreamFX { get; set; }
        protected Un4seen.Bass.Misc.Visuals visuals;

        #endregion

        public Player()
        {
            register();
            visuals = new Un4seen.Bass.Misc.Visuals();
        }

        #region init

        private void register()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(@"assets\nBASSAuth.xml");

            XmlNode first = xml.LastChild;
            XmlNodeList list = first.ChildNodes;
            XmlNode node = list.Item(0);

            String user = SnakeSecurity.decrypt(node.ChildNodes.Item(0).InnerText, "10");
            String pass = SnakeSecurity.decrypt(node.ChildNodes.Item(1).InnerText, "10");

            BassNet.Registration(user, pass);
        }

        public bool initPLayer()
        {
            IsInit = Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);

            return IsInit;
        }

        #endregion init

        #region player

        public void pause()
        {
            Bass.BASS_ChannelPause(Stream);
        }

        public void stop()
        {
            Bass.BASS_ChannelStop(Stream);
        }

        public int play(string name)
        {
            Bass.BASS_ChannelPause(Stream);

            // create a stream channel from a file 
            Stream = Bass.BASS_StreamCreateFile(name, 0, 0, BASSFlag.BASS_DEFAULT);

            if (Stream != 0)
            {
                // play the stream channel 
                Bass.BASS_ChannelPlay(Stream, false);

                return Stream;
            }

            //MessageBox.Show(Bass.BASS_ErrorGetCode().ToString());
            return 0;

        }

        public bool isStopped()
        {
            BASSActive status = Bass.BASS_ChannelIsActive(Stream);
            if (status == BASSActive.BASS_ACTIVE_STOPPED)
            {
                return true;
            }

            return false;
        }

        public void mute()
        {
            Bass.BASS_ChannelSetAttribute(Stream, BASSAttribute.BASS_ATTRIB_VOL, 0.0f);
        }

        public void setVolume(float val)
        {
            Bass.BASS_ChannelSetAttribute(Stream, BASSAttribute.BASS_ATTRIB_VOL, val);
        }

        public void setSpeakerPan(float side)
        {
            Bass.BASS_ChannelSetAttribute(Stream, BASSAttribute.BASS_ATTRIB_PAN, side);
        }

        public void seekSong(double secs)
        {
            Bass.BASS_ChannelPause(Stream);
            Bass.BASS_ChannelSetPosition(Stream, Bass.BASS_ChannelSeconds2Bytes(Stream, secs));
            Bass.BASS_ChannelPlay(Stream, false);
        }

        public Bitmap visualisator(Visual visual, int Width, int Height,
            Color colorDown, Color colorUpper, Color background,
            int linewidth, int distance, bool liear, bool fullSpectrum, bool highQuality)
        {

            Bitmap bmp = null;

            switch (visual)
            {
                case Visual.Spectrum:
                    bmp = visuals.CreateSpectrumLine(Stream, Width, Height,
                                               colorDown, colorUpper, background,
                                               linewidth, distance, liear,
                                               fullSpectrum, highQuality);
                    break;
                case Visual.SpectrumLine:
                    bmp = visuals.CreateSpectrum(Stream, Width, Height,
                                colorDown, colorUpper, background,
                                liear, fullSpectrum, highQuality);
                    break;
                case Visual.WaveForm:
                    bmp = visuals.CreateWaveForm(Stream, Width, Height,
                                colorDown, colorUpper, background,
                                Color.Wheat, linewidth, fullSpectrum,
                                liear, highQuality);
                    break;
                default:
                    break;
            }

            return bmp;
        }

        public Position whereIsSong()
        {
            Position positoin = new Position();

            //determine where is now
            long bis = Bass.BASS_ChannelGetPosition(Stream);//current position in stream
            double sec = Bass.BASS_ChannelBytes2Seconds(Stream, bis);//transfer to seconds in double

            String come2 = (TimeSpan.FromSeconds(sec).Minutes + ":" + TimeSpan.FromSeconds(sec).Seconds);//present
            positoin.Current = come2;

            positoin.PositionSong = (TimeSpan.FromSeconds(sec).Minutes * 60 + TimeSpan.FromSeconds(sec).Seconds);//must calculate the real position!

            return positoin;
        }

        public int time()
        {
            TAG_INFO tag_info = new TAG_INFO();
            BassTags.BASS_TAG_GetFromFile(Stream, tag_info);
            return (TimeSpan.FromSeconds(tag_info.duration).Minutes * 60 + TimeSpan.FromSeconds(tag_info.duration).Seconds);
        }

        public String songTime()
        {
            TAG_INFO tag_info = new TAG_INFO();
            BassTags.BASS_TAG_GetFromFile(Stream, tag_info);

            String fullTime = (TimeSpan.FromSeconds(tag_info.duration).Minutes + ":" + TimeSpan.FromSeconds(tag_info.duration).Seconds);

            return fullTime;
        }

        public SongInfo songInfo()
        {
            SongInfo info = new SongInfo();

            TAG_INFO tag_info = new TAG_INFO();
            BassTags.BASS_TAG_GetFromFile(Stream, tag_info);
            info.Artist = tag_info.artist;
            info.Title = tag_info.title;
            info.Duration = tag_info.duration;

            if (tag_info.PictureCount > 0)
            {
                info.Img = tag_info.PictureGetImage(0);
            }

            info.FullSongTime = songTime();

            int Maximum = (TimeSpan.FromSeconds(tag_info.duration).Minutes * 60 + TimeSpan.FromSeconds(tag_info.duration).Seconds);
            info.songDuration = Maximum;

            return info;
        }

        #endregion player

        #region free

        public void freeAll()
        {
            Bass.BASS_Stop();
            Bass.BASS_StreamFree(Stream);
            Bass.BASS_StreamFree(StreamFX);
            Bass.BASS_Free();
        }

        #endregion free

        #region stream_fx

        public void resetStreamFXtoStream()
        {
            Stream = BassFx.BASS_FX_ReverseGetSource(StreamFX);
        }

        public void createFXFile(String fileName)
        {
            Stream = Bass.BASS_StreamCreateFile(fileName, 0L, 0L, BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_STREAM_PRESCAN);
        }

        public void createFXCTempoChanel()
        {
            StreamFX = BassFx.BASS_FX_TempoCreate(Stream, BASSFlag.BASS_FX_FREESOURCE);
        }

        public bool setTempoAttr(float tempo)
        {
            if (tempo >= -95f || tempo <= 95f)
            {
                Bass.BASS_ChannelSetAttribute(StreamFX, BASSAttribute.BASS_ATTRIB_TEMPO, 500f);
                return true;
            }

            return false;
        }

        public void createFXCDirectionFlowChanel()
        {
            StreamFX = BassFx.BASS_FX_ReverseCreate(Stream, 2f, BASSFlag.BASS_FX_FREESOURCE);
        }

        public void setDirectionFlow(FlowDirection flow)
        {
            switch (flow)
            {
                case FlowDirection.FORWARD:
                    Bass.BASS_ChannelSetAttribute(StreamFX, BASSAttribute.BASS_ATTRIB_REVERSE_DIR, (float)BASSFXReverse.BASS_FX_RVS_FORWARD);
                    break;
                case FlowDirection.REVERSE:
                    Bass.BASS_ChannelSetAttribute(StreamFX, BASSAttribute.BASS_ATTRIB_REVERSE_DIR, (float)BASSFXReverse.BASS_FX_RVS_REVERSE);
                    break;
                default:
                    Bass.BASS_ChannelSetAttribute(StreamFX, BASSAttribute.BASS_ATTRIB_REVERSE_DIR, (float)BASSFXReverse.BASS_FX_RVS_FORWARD);
                    break;
            }
        }

        #endregion

        #region read_all_devices

        public List<String> getAllDevices()
        {
            List<String> devices = new List<string>();

            BASS_DEVICEINFO[] devs = Bass.BASS_GetDeviceInfos();
            foreach (BASS_DEVICEINFO dev in devs)
            {
                devices.Add(dev.ToString());
            }

            return devices;
        }
        #endregion

    }
}
