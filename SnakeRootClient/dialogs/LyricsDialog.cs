using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SnakeRootClient.dialogs
{
    public partial class LyricsDialog : Form
    {
        public LyricsDialog(String[] result)
        {
            InitializeComponent();
            richTextBox1.ReadOnly = true;
            richTextBox1.Text = result[1];
            richTextBox1.Text += result[2];
            richTextBox1.Text += result[3];
        }
    }
}
