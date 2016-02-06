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
    public partial class PhotosDialog : Form
    {
        public PhotosDialog(List<Image> images)
        {
            InitializeComponent();

            foreach (Image img in images)
            {
                PictureBox pb = new PictureBox()
                {
                    Size = new Size(200, 200),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    //Tag = res.OriginalContextUrl,
                    Image = img,
                };

                pb.MouseEnter += new EventHandler(pb_MouseEnter);
                pb.MouseLeave += new EventHandler(pb_MouseLeave2);

                flowLayoutPanel1.Controls.Add(pb);
                flowLayoutPanel1.WrapContents = true;
            }

        }

        void pb_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Size = new Size(250, 250);
        }

        void pb_MouseLeave2(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Size = new Size(200, 200);
        }

        private void PhotosDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
