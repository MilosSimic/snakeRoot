using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Google.API.Search;
using System.Web;
using System.Net;
using System.IO;
using SnakeRootClient.dialogs;
using Microsoft.WindowsAPICodePack;
using Microsoft.WindowsAPICodePack.Taskbar;
using Microsoft.WindowsAPICodePack.Shell;
using System.Xml.Schema;
using SnakeRootCore;
using SnakeRootCore.info;
using SnakeRootCore.visuals;
using System.Xml;
using System.Xml.Linq;

namespace SnakeRootClient
{
    public partial class Form1 : Form
    {
        protected CoreAPI core;
        protected bool init;
        protected List<Image> images;
        private int amount = 0;
        private int tweet = 0;
        private int MIN = 60;
        protected TaskbarManager tbManager = TaskbarManager.Instance;
        protected Timer timer4;

        public Form1()
        {
            InitializeComponent();
            core = new CoreAPI();
            init = core.init();
            listBox1.MouseDoubleClick += new MouseEventHandler(listBox1_MouseDoubleClick);
            initDialog();
            images = new List<Image>();
            timer2.Tick += new EventHandler(timer2_Tick);

            initWorkers();
            initToolbar();
            initFormEvents();
            initTimer();
        }

        #region INIT

        private void initTimer()
        {
            timer4 = new Timer();
            timer4.Interval = 1000;
            timer4.Tick += new EventHandler(timer4_Tick);
        }

        private void initFormEvents()
        {
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            this.Shown += new EventHandler(Form1_Shown);
            this.Resize += new EventHandler(Form1_Resize);
        }

        private void initWorkers()
        {
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);

            backgroundWorker2.DoWork += new DoWorkEventHandler(backgroundWorker2_DoWork);
            backgroundWorker2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker2_RunWorkerCompleted);
        }

        #endregion

        #region toolbar

        void timer4_Tick(object sender, EventArgs e)
        {
            tbManager.SetProgressValue(trackBar2.Value, trackBar2.Maximum);
        }

        void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                timer4.Start();
                timer4.Enabled = true;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                timer4.Stop();
                timer4.Enabled = false;
                tbManager.SetProgressValue(0, trackBar2.Maximum);
            }
        }

        void Form1_Shown(object sender, EventArgs e)
        {
            tbManager.TabbedThumbnail.SetThumbnailClip(this.Handle, new Rectangle(pictureBox1.Location, pictureBox1.Size));
        }

        private void initToolbar()
        {
            //System.Drawing.Icon i = new System.Drawing.Icon(@"assets\play.ico", 16, 16);
            ThumbnailToolbarButton buttonPause = new ThumbnailToolbarButton(new System.Drawing.Icon(@"assets\play.ico", 16, 16), "Pause song");
            buttonPause.Click += new EventHandler<ThumbnailButtonClickedEventArgs>(buttonPlayPause_Click);
            ThumbnailToolbarButton buttonStop = new ThumbnailToolbarButton(new System.Drawing.Icon(@"assets\stop.ico", 16, 16), "Stop song");
            buttonStop.Click += new EventHandler<ThumbnailButtonClickedEventArgs>(buttonStop_Click);
            ThumbnailToolbarButton buttonPlay = new ThumbnailToolbarButton(new System.Drawing.Icon(@"assets\pause.ico", 16, 16), "Play song");
            buttonPlay.Click += new EventHandler<ThumbnailButtonClickedEventArgs>(buttonPlay_Click);


            tbManager.ThumbnailToolbars.AddButtons(this.Handle, buttonPause, buttonPlay, buttonStop);
            //tbManager.TabbedThumbnail.SetThumbnailClip(this.Handle, new Rectangle(pictureBox1.Location, pictureBox1.Size));
        }

        private void SetTimerforPlay()
        {
            tbManager.SetProgressState(TaskbarProgressBarState.Normal);

        }

        void buttonPlay_Click(object sender, ThumbnailButtonClickedEventArgs e)
        {
            int index = listBox1.SelectedIndex;

            if (index != -1)
            {
                play(index);
            }
        }

        void buttonStop_Click(object sender, ThumbnailButtonClickedEventArgs e)
        {
            trackBar2.Value = 0;
            core.stop();

            timer1.Stop();
            timer2.Stop();
        }

        private void setTimerForPause()
        {
            core.pause();
            tbManager.SetProgressState(TaskbarProgressBarState.Paused);
        }

        void buttonPlayPause_Click(object sender, ThumbnailButtonClickedEventArgs e)
        {
            setTimerForPause();
        }

        #endregion

        #region async web calls

        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Operation canceled");
            }
            else
            {
                if (e.Error != null)
                {
                    MessageBox.Show(e.Error.Message);
                }
                else
                {
                    String[] result = (String[])e.Result;
                    if(result != null)
                    {
                        toolStripStatusLabel2.Visible = true;
                        toolStripStatusLabel2.Tag = result;
                    }
                }
            }
        }

        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            SongInfo inf = (SongInfo)e.Argument;
            String[] result = core.getLyrics(inf.Artist, inf.Title);//Lyrics or NULL
            e.Result = result;
        }

        void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Operation canceled");
            }
            else
            {
                if (e.Error != null)
                {
                    MessageBox.Show(e.Error.Message);
                }
                else
                {
                    String result = (String)e.Result;
                    if (result != null)
                    {
                        toolStripStatusLabel3.Visible = true;
                        toolStripStatusLabel3.Tag = result;
                    }
                }
            }
        }

        void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            SongInfo inf = (SongInfo)e.Argument;
            String result = core.getInfo(inf.Artist);//info or NULL
            e.Result = result;
        }

        #endregion

        #region events

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            core.freeAll();
        }

        #endregion events

        #region initDialog

        private void selfFindPictures(String text, int minutes)
        {
            try
            {
                GimageSearchClient client = new GimageSearchClient("http://www.google.com");
                IList<IImageResult> results;
                IAsyncResult result = client.BeginSearch(text.Trim(), minutes,
                                                        ((arResult) =>
                                                        {
                                                            results = client.EndSearch(arResult);
                                                            if (results != null)
                                                            {
                                                                images.Clear();
                                                                foreach (IImageResult res in results)
                                                                {
                                                                    //images.Add(res.Url);
                                                                    var wc = new WebClient();
                                                                    Image xImage = Image.FromStream(wc.OpenRead(res.Url));
                                                                    images.Add(xImage);
                                                                    //xImage.Save("jovan");
                                                                    //this.BackgroundImage = xImage;
                                                                }

                                                            }
                                                        }),
                                                        null);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            /*timer3.Enabled = true;
            timer3.Start();
            timer3.Enabled = true;*/
            toolStripStatusLabel5.Visible = true;
        }

        private void initDialog()
        {
            openFileDialog1.Filter = "mp3 files (*.mp3)|*.mp3";
            openFileDialog1.DefaultExt = "mp3";
            openFileDialog1.Title = "Browse MP3 Files";
            openFileDialog1.Multiselect = true;
        }

        #endregion initDialog

        #region player event

        void timer2_Tick(object sender, EventArgs e)
        {
            Position position = core.whereIsSong();
            trackBar2.Value = position.PositionSong;
            //TODO:OVO ODKOMENTARISATI AKO NE BUDE RADILO NA MINIMIZE
            //tbManager.SetProgressValue(trackBar2.Value,trackBar2.Maximum);
            label2.Text = core.songTime() + "/" + position.Current;
        }

        void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);

            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                play(index);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setTimerForPause();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            core.stop();

            trackBar2.Value = 0;

            timer1.Stop();
            timer2.Stop();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if(index != -1){
                play(index);
            }
        }

        private void play(int index)
        {
            List<String> path = (List<String>)listBox1.Tag;

            if (path != null)
            {
                core.playSong(path.ElementAt(index));
                setInfo();


                if (core.DNSTest())
                {
                    int minutes = TimeSpan.FromSeconds(core.songInfo().Duration).Minutes;
                    selfFindPictures(core.songInfo().Artist, minutes);
                }

                SetTimerforPlay();

                runWorkers();

            }
        }

        private void runWorkers()
        {
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.CancelAsync();
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync(core.songInfo());
            }

            backgroundWorker2.WorkerSupportsCancellation = true;
            backgroundWorker2.CancelAsync();
            if (!backgroundWorker2.IsBusy)
            {
                backgroundWorker2.RunWorkerAsync(core.songInfo());
            }
        }

        private void playNext()
        {
            if(listBox1.Items.Count > 0)
            {
                //check is palying
                if (core.isStopped())
                {
                    //hide posible net buttons
                    toolStripStatusLabel2.Visible = false;
                    toolStripStatusLabel3.Visible = false;
                    toolStripStatusLabel4.Visible = false;
                    toolStripStatusLabel5.Visible = false;

                    //hold the timer
                    timer1.Stop();
                    timer2.Stop();

                    //get the index
                    int index = listBox1.SelectedIndex;

                    //see who is next
                    if (index < listBox1.Items.Count - 1)
                    {
                        index++;
                    }
                    else
                    {
                        index = 0;
                    }

                    //play next
                    play(index);

                    //select in list
                    listBox1.SelectedIndex = index;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            visualise(4);

            //check is palying
            playNext();
        }

        private void visualise(int size)
        {
            if (amount % size == 0)
            {
                pictureBox1.Image = core.visualisator(Visual.SpectrumLine, pictureBox1.Width, pictureBox1.Height,
                Color.Blue, Color.Gray, Color.Black, 3, 2, false, false, false);
            }
            else if (amount % size == 1)
            {
                pictureBox1.Image = core.visualisator(Visual.Spectrum, pictureBox1.Width, pictureBox1.Height,
                Color.Blue, Color.Gray, Color.Black, 3, 2, false, false, false);
            }
            else if (amount % size == 2)
            {
                pictureBox1.Image = core.visualisator(Visual.WaveForm, pictureBox1.Width, pictureBox1.Height,
                Color.Blue, Color.Gray, Color.Black, 3, 2, false, false, false);
            }
            else
            {
                if (core.songInfo().Img != null)
                {
                    pictureBox1.Image = core.songInfo().Img;
                }
            }
        }

        private void setInfo()
        {
            toolStripStatusLabel1.Text = "NOW PLAYING:"+ core.songInfo().Artist + "-" + core.songInfo().Title;
            if(core.DNSTest()){
                toolStripStatusLabel4.Visible = true;
            }
            trackBar2.Maximum = core.time();
            timer1.Start();
            timer2.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            core.mute();
            trackBar1.Value = 0;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            float side = (float)trackBar3.Value / 10;
            core.setSpeakerPan(side);
            toolTip3.SetToolTip(trackBar3, trackBar3.Value.ToString());
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            timer2.Stop();

            double secs = (double)trackBar2.Value;
            core.seekSong(secs);

            toolTip2.SetToolTip(trackBar2, (TimeSpan.FromSeconds(secs).Minutes + ":" + TimeSpan.FromSeconds(secs).Seconds).ToString());

            timer2.Enabled = true;
            timer1.Start();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            float val = (float)trackBar1.Value / 100;
            //menja volue bas pesme
            core.setVolume(val);
            toolTip1.SetToolTip(trackBar1, trackBar1.Value.ToString());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            amount++;
        }


        #endregion

        #region playlist event

        private void button1_Click(object sender, EventArgs e)
        {
            if (init)
            {
                initDialog();
                DialogResult res = openFileDialog1.ShowDialog();

                if (res == System.Windows.Forms.DialogResult.OK)
                {

                    //listBox1.Items.Clear();
                    List<String> paths = new List<string>();
                    foreach (String file in openFileDialog1.FileNames)
                    {
                        paths.Add(file);
                        char[] st = { '\\' };
                        String[] name = file.Split(st);
                        listBox1.Items.Add(name[name.Length - 1]);
                    }

                    if (listBox1.Tag != null)
                    {
                        List<String> lists = (List<String>)listBox1.Tag;
                        lists.AddRange(paths);
                        listBox1.Tag = lists;
                    }
                    else
                    {
                        listBox1.Tag = paths;
                    }  
                }
            }
        }

        #endregion

        #region toolstrip events

        private void toolStripStatusLabel5_Click(object sender, EventArgs e)
        {
            PhotosDialog diag = new PhotosDialog(images);
            diag.ShowDialog(this);
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            ToolStripLabel label = (ToolStripLabel)sender;
            String[] result = (String[])label.Tag;

            LyricsDialog diag = new LyricsDialog(result);
            diag.ShowDialog(this);
        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {
            if (tweet % 2 == 0)
            {
                tweetGroup.Visible = true;
                textBox1.Text = core.songInfo().Artist + "-" + core.songInfo().Title;
            }
            else
            {
                tweetGroup.Visible = false;
            }

            tweet++;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (core.DNSTest())
            {
                core.tweet(textBox1.Text.Trim());
            }
            else
            {
                MessageBox.Show("No internet connection!");
            }
        }

        int pictureIndex = 0;
        int counter = 0;
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (counter == MIN)
            {
                counter = 0;
                if(pictureIndex >= images.Count){
                    pictureIndex = 0;
                }
                this.BackgroundImageLayout = ImageLayout.Stretch;
                this.BackgroundImage = images.ElementAt(pictureIndex);
                pictureIndex++;
            }
            
            counter++;
            //System.Diagnostics.Debug.Write("VREDNOST:" + counter);
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            ToolStripLabel label = (ToolStripLabel)sender;
            String info = (String)label.Tag;

            WebDialog dialog = new WebDialog(info);
            dialog.ShowDialog(this);
        }

        #endregion

        #region CONTEXTMENU

        private void button10_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
        }

        void clearList_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Tag = null;
        }

        void saveList_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "xml files (*.xml)|*.xml";
            saveFileDialog1.DefaultExt = "xml";
            saveFileDialog1.Title = "Save List Files";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                List<String> list = (List<String>)listBox1.Tag;

                core.save(list, saveFileDialog1.FileName);
            }
        }

        void openList_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            openFileDialog1.Filter = "xml files (*.xml)|*.xml";
            openFileDialog1.DefaultExt = "xml";
            openFileDialog1.Title = "Open List Files";
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (core.validateInput(openFileDialog1.FileName))
                {

                    if(listBox1.Items.Count > 0){
                        listBox1.Items.Clear();
                    }

                    List<String> list = new List<string>();

                    core.loadList(list, openFileDialog1.FileName);

                    listBox1.Tag = list;

                    foreach (string s in list)
                    {
                        char[] st = { '\\' };
                        String[] name = s.Split(st);
                        listBox1.Items.Add(name[name.Length - 1]);
                    }
                }
                else
                {
                    MessageBox.Show("No SnakeRoot playlist file");
                }
            }
        }

        #endregion

        private void toolStripStatusLabel6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Author:Milos Simic\nContact:\nmilossimicsimo@gmail.com\nhttps://www.facebook.com/milos.simo.1\n");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;
            
        }

    }

}
