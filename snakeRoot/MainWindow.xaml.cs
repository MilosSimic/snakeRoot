using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using snakeRootlib;
using LyricsCrawler;
using LyricsCrawler.assets;
using System.Windows.Forms;
using System.Drawing;

namespace snakeRoot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected Player player;
        protected Timer timer1;
        protected Timer timer2;

        public MainWindow()
        {
            InitializeComponent();
            player = new Player();

            timer1 = new Timer();
            timer1.Interval = 50;
            timer1.Tick += new EventHandler(timer1_Tick);

            timer2 = new Timer();
            timer2.Interval = 1000;
            timer2.Tick += new EventHandler(timer2_Tick);
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            visualisator.Source = player.visualisator(snakeRootlib.visuals.Visual.SpectrumLine,
                (int)visualisator.Width, (int)visualisator.Height, System.Drawing.Color.Red, System.Drawing.Color.Green, System.Drawing.Color.Black,
                3, 2, false, false, false);
        }

        void timer2_Tick(object sender, EventArgs e)
        {
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            player.freeAll();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (this.listBox1.SelectedIndex != -1)
            {
                //String value = (String) listBox1.Items.GetItemAt(this.listBox1.SelectedIndex);
                List<String> path = (List<String>)listBox1.Tag;
                String value = path[listBox1.SelectedIndex];
                player.play(value);
            }
        }

        private void openList_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "mp3 files (*.mp3)|*.mp3";
            dlg.DefaultExt = "mp3";
            dlg.Title = "Browse MP3 Files";
            dlg.Multiselect = true;

            if(player.IsInit){
                // Display OpenFileDialog by calling ShowDialog method
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    List<String> paths = new List<string>();
                    
                    foreach (String file in dlg.FileNames)
                    {
                        paths.Add(file);
                        char[] st = {'\\'};
                        String[] name = file.Split(st);
                        //MessageBox.Show(name[name.Length - 1]);
                        listBox1.Items.Add(name[name.Length - 1]);
                    }

                    listBox1.Tag = paths;
                }
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.listBox1.SelectedIndex != -1)
            {
                //String value = (String) listBox1.Items.GetItemAt(this.listBox1.SelectedIndex);
                List<String> path = (List<String>)listBox1.Tag;
                String value = path[listBox1.SelectedIndex];
                player.play(value);
            }

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            player.stop();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            player.pause();
        }

        private void image3_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            player.mute();
            volume.Value = 0;
        }

        private void volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            float val = (float)volume.Value / 100;
            player.setVolume(val);
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            float side = (float)slider1.Value / 10;
            player.setSpeakerPan(side);
        }
    }
}
