namespace ImageGUI
{
    partial class ParallelImage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            openFileDialog1 = new OpenFileDialog();
            pictureBoxMain = new PictureBox();
            buttonLoad = new Button();
            buttonProcess = new Button();
            numericUpDown1 = new NumericUpDown();
            labelThreads = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBoxMain
            // 
            pictureBoxMain.Location = new Point(116, 206);
            pictureBoxMain.Name = "pictureBoxMain";
            pictureBoxMain.Size = new Size(300, 300);
            pictureBoxMain.TabIndex = 0;
            pictureBoxMain.TabStop = false;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(495, 310);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(88, 38);
            buttonLoad.TabIndex = 1;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonProcess
            // 
            buttonProcess.Location = new Point(495, 388);
            buttonProcess.Name = "buttonProcess";
            buttonProcess.Size = new Size(88, 39);
            buttonProcess.TabIndex = 2;
            buttonProcess.Text = "Process Images";
            buttonProcess.UseVisualStyleBackColor = true;
            buttonProcess.Click += buttonProcess_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(495, 267);
            numericUpDown1.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(88, 23);
            numericUpDown1.TabIndex = 3;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelThreads
            // 
            labelThreads.AutoSize = true;
            labelThreads.Location = new Point(495, 249);
            labelThreads.Name = "labelThreads";
            labelThreads.Size = new Size(46, 15);
            labelThreads.TabIndex = 4;
            labelThreads.Text = "threads";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(646, 57);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(300, 300);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(952, 57);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(300, 300);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(646, 369);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(300, 300);
            pictureBox3.TabIndex = 7;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Location = new Point(952, 369);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(300, 300);
            pictureBox4.TabIndex = 8;
            pictureBox4.TabStop = false;
            // 
            // ParallelImage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(labelThreads);
            Controls.Add(numericUpDown1);
            Controls.Add(buttonProcess);
            Controls.Add(buttonLoad);
            Controls.Add(pictureBoxMain);
            Name = "ParallelImage";
            Text = "ParallelImage";
            ((System.ComponentModel.ISupportInitialize)pictureBoxMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private PictureBox pictureBoxMain;
        private Button buttonLoad;
        private Button buttonProcess;
        private NumericUpDown numericUpDown1;
        private Label labelThreads;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
    }
}
