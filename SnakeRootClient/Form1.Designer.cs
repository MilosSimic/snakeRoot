namespace SnakeRootClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.tweetGroup = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.separator = new System.Windows.Forms.ToolStripSeparator();
            this.button10 = new System.Windows.Forms.Button();
            this.openList = new System.Windows.Forms.ToolStripMenuItem();
            this.saveList = new System.Windows.Forms.ToolStripMenuItem();
            this.clearList = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tweetGroup.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar2
            // 
            this.trackBar2.LargeChange = 1;
            this.trackBar2.Location = new System.Drawing.Point(2, 124);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(262, 45);
            this.trackBar2.TabIndex = 20;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "0:0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Right";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Left";
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(59, 260);
            this.trackBar3.Minimum = -10;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(114, 45);
            this.trackBar3.TabIndex = 28;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 6;
            this.trackBar1.Location = new System.Drawing.Point(8, 210);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(228, 45);
            this.trackBar1.SmallChange = 2;
            this.trackBar1.TabIndex = 25;
            this.trackBar1.TickFrequency = 2;
            this.trackBar1.Value = 18;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6});
            this.statusStrip1.Location = new System.Drawing.Point(0, 380);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(604, 22);
            this.statusStrip1.TabIndex = 31;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(96, 17);
            this.toolStripStatusLabel1.Text = "NOW PLAYEING:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusLabel2.Text = "see lyrics now";
            this.toolStripStatusLabel2.Visible = false;
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabel3.Text = "band information";
            this.toolStripStatusLabel3.Visible = false;
            this.toolStripStatusLabel3.Click += new System.EventHandler(this.toolStripStatusLabel3_Click);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(36, 17);
            this.toolStripStatusLabel4.Text = "tweet";
            this.toolStripStatusLabel4.Visible = false;
            this.toolStripStatusLabel4.Click += new System.EventHandler(this.toolStripStatusLabel4_Click);
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(115, 17);
            this.toolStripStatusLabel5.Text = "sample band photos";
            this.toolStripStatusLabel5.Visible = false;
            this.toolStripStatusLabel5.Click += new System.EventHandler(this.toolStripStatusLabel5_Click);
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel6.Text = "about";
            this.toolStripStatusLabel6.Click += new System.EventHandler(this.toolStripStatusLabel6_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(337, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(260, 342);
            this.listBox1.TabIndex = 33;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(337, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 22);
            this.button1.TabIndex = 32;
            this.button1.Text = "Import";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            // 
            // tweetGroup
            // 
            this.tweetGroup.Controls.Add(this.button6);
            this.tweetGroup.Controls.Add(this.textBox1);
            this.tweetGroup.Location = new System.Drawing.Point(7, 303);
            this.tweetGroup.Name = "tweetGroup";
            this.tweetGroup.Size = new System.Drawing.Size(257, 67);
            this.tweetGroup.TabIndex = 35;
            this.tweetGroup.TabStop = false;
            this.tweetGroup.Text = "Tweet";
            this.tweetGroup.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 15);
            this.textBox1.MaxLength = 140;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(203, 46);
            this.textBox1.TabIndex = 0;
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openList,
            this.saveList,
            this.separator,
            this.clearList});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 76);
            // 
            // separator
            // 
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(143, 6);
            // 
            // button10
            // 
            this.button10.ContextMenuStrip = this.contextMenuStrip1;
            this.button10.Location = new System.Drawing.Point(517, 350);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(80, 23);
            this.button10.TabIndex = 41;
            this.button10.Text = "Playlist";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // openList
            // 
            this.openList.Image = global::SnakeRootClient.Properties.Resources._1403369285_186404;
            this.openList.Name = "openList";
            this.openList.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openList.Size = new System.Drawing.Size(146, 22);
            this.openList.Text = "Open";
            this.openList.Click += new System.EventHandler(this.openList_Click);
            // 
            // saveList
            // 
            this.saveList.Image = global::SnakeRootClient.Properties.Resources._1403369323_186405;
            this.saveList.Name = "saveList";
            this.saveList.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveList.Size = new System.Drawing.Size(146, 22);
            this.saveList.Text = "Save";
            this.saveList.Click += new System.EventHandler(this.saveList_Click);
            // 
            // clearList
            // 
            this.clearList.Image = global::SnakeRootClient.Properties.Resources._1403369275_186389;
            this.clearList.Name = "clearList";
            this.clearList.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.clearList.Size = new System.Drawing.Size(146, 22);
            this.clearList.Text = "Clear";
            this.clearList.Click += new System.EventHandler(this.clearList_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SnakeRootClient.Properties.Resources.speaker;
            this.pictureBox2.Location = new System.Drawing.Point(2, 260);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(23, 26);
            this.pictureBox2.TabIndex = 39;
            this.pictureBox2.TabStop = false;
            // 
            // button6
            // 
            this.button6.Image = global::SnakeRootClient.Properties.Resources.Twitter_button;
            this.button6.Location = new System.Drawing.Point(219, 28);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(29, 23);
            this.button6.TabIndex = 1;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Image = global::SnakeRootClient.Properties.Resources.play;
            this.button7.Location = new System.Drawing.Point(126, 172);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(35, 30);
            this.button7.TabIndex = 27;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button4
            // 
            this.button4.Image = global::SnakeRootClient.Properties.Resources.mute;
            this.button4.Location = new System.Drawing.Point(233, 210);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(31, 23);
            this.button4.TabIndex = 26;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Image = global::SnakeRootClient.Properties.Resources.pause;
            this.button3.Location = new System.Drawing.Point(167, 172);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(35, 30);
            this.button3.TabIndex = 24;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Image = global::SnakeRootClient.Properties.Resources.stop;
            this.button2.Location = new System.Drawing.Point(85, 172);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 30);
            this.button2.TabIndex = 23;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(314, 116);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 402);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.tweetGroup);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SnakeRoot Client";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tweetGroup.ResumeLayout(false);
            this.tweetGroup.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.GroupBox tweetGroup;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openList;
        private System.Windows.Forms.ToolStripMenuItem saveList;
        private System.Windows.Forms.ToolStripMenuItem clearList;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ToolStripSeparator separator;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
    }
}

