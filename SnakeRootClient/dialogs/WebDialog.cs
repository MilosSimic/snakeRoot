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
    public partial class WebDialog : Form
    {
        public WebDialog(String html)
        {
            InitializeComponent();
            webBrowser1.DocumentText = html;
        }

    }
}
