namespace FileCompare
{
    partial class Form1
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
            ColumnHeader Name;
            splitContainer1 = new SplitContainer();
            panel2 = new Panel();
            btnLeftDir = new Button();
            txtLeftDir = new TextBox();
            panel3 = new Panel();
            lvwLeftDir = new ListView();
            Mom = new ColumnHeader();
            Date = new ColumnHeader();
            panel1 = new Panel();
            btnCopyFromLeft = new Button();
            lblAppName = new Label();
            panel8 = new Panel();
            lvwRightDir = new ListView();
            Ｎａｍｅ = new ColumnHeader();
            Ｍｏｍ = new ColumnHeader();
            Ｄａｔｅ = new ColumnHeader();
            panel5 = new Panel();
            btnRightDir = new Button();
            txtRightDir = new TextBox();
            panel4 = new Panel();
            btnCopyFromRight = new Button();
            Name = new ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel8.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // Name
            // 
            Name.Text = "이름";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel2);
            splitContainer1.Panel1.Controls.Add(panel3);
            splitContainer1.Panel1.Controls.Add(panel1);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel8);
            splitContainer1.Panel2.Controls.Add(panel5);
            splitContainer1.Panel2.Controls.Add(panel4);
            splitContainer1.Size = new Size(829, 455);
            splitContainer1.SplitterDistance = 396;
            splitContainer1.TabIndex = 0;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnLeftDir);
            panel2.Controls.Add(txtLeftDir);
            panel2.Location = new Point(3, 85);
            panel2.Name = "panel2";
            panel2.Size = new Size(390, 87);
            panel2.TabIndex = 1;
            // 
            // btnLeftDir
            // 
            btnLeftDir.Location = new Point(301, 31);
            btnLeftDir.Name = "btnLeftDir";
            btnLeftDir.Size = new Size(83, 29);
            btnLeftDir.TabIndex = 4;
            btnLeftDir.Text = "폴더선택";
            btnLeftDir.UseVisualStyleBackColor = true;
            btnLeftDir.Click += btnLeftDir_Click;
            // 
            // txtLeftDir
            // 
            txtLeftDir.Location = new Point(9, 32);
            txtLeftDir.Name = "txtLeftDir";
            txtLeftDir.Size = new Size(286, 27);
            txtLeftDir.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(lvwLeftDir);
            panel3.Location = new Point(3, 178);
            panel3.Name = "panel3";
            panel3.Size = new Size(390, 269);
            panel3.TabIndex = 1;
            // 
            // lvwLeftDir
            // 
            lvwLeftDir.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvwLeftDir.Columns.AddRange(new ColumnHeader[] { Name, Mom, Date });
            lvwLeftDir.FullRowSelect = true;
            lvwLeftDir.GridLines = true;
            lvwLeftDir.Location = new Point(0, 0);
            lvwLeftDir.Name = "lvwLeftDir";
            lvwLeftDir.Size = new Size(390, 274);
            lvwLeftDir.TabIndex = 0;
            lvwLeftDir.UseCompatibleStateImageBehavior = false;
            lvwLeftDir.View = View.Details;
            // 
            // Mom
            // 
            Mom.Text = "크기";
            Mom.Width = 200;
            // 
            // Date
            // 
            Date.Text = "수정일";
            Date.Width = 130;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCopyFromLeft);
            panel1.Controls.Add(lblAppName);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(390, 87);
            panel1.TabIndex = 0;
            // 
            // btnCopyFromLeft
            // 
            btnCopyFromLeft.BackColor = SystemColors.Desktop;
            btnCopyFromLeft.Location = new Point(291, 19);
            btnCopyFromLeft.Name = "btnCopyFromLeft";
            btnCopyFromLeft.Size = new Size(83, 29);
            btnCopyFromLeft.TabIndex = 2;
            btnCopyFromLeft.Text = ">>>";
            btnCopyFromLeft.UseVisualStyleBackColor = false;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("한컴 말랑말랑 Regular", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblAppName.ForeColor = SystemColors.Highlight;
            lblAppName.Location = new Point(20, 19);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(249, 47);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "File Compare";
            // 
            // panel8
            // 
            panel8.Controls.Add(lvwRightDir);
            panel8.Location = new Point(7, 184);
            panel8.Name = "panel8";
            panel8.Size = new Size(414, 263);
            panel8.TabIndex = 3;
            // 
            // lvwRightDir
            // 
            lvwRightDir.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvwRightDir.Columns.AddRange(new ColumnHeader[] { Ｎａｍｅ, Ｍｏｍ, Ｄａｔｅ });
            lvwRightDir.FullRowSelect = true;
            lvwRightDir.GridLines = true;
            lvwRightDir.Location = new Point(-2, -6);
            lvwRightDir.Name = "lvwRightDir";
            lvwRightDir.Size = new Size(416, 274);
            lvwRightDir.TabIndex = 1;
            lvwRightDir.UseCompatibleStateImageBehavior = false;
            lvwRightDir.View = View.Details;
            // 
            // Ｎａｍｅ
            // 
            Ｎａｍｅ.Text = "이름";
            // 
            // Ｍｏｍ
            // 
            Ｍｏｍ.Text = "크기";
            Ｍｏｍ.Width = 200;
            // 
            // Ｄａｔｅ
            // 
            Ｄａｔｅ.Text = "수정일";
            Ｄａｔｅ.Width = 130;
            // 
            // panel5
            // 
            panel5.Controls.Add(btnRightDir);
            panel5.Controls.Add(txtRightDir);
            panel5.Location = new Point(5, 88);
            panel5.Name = "panel5";
            panel5.Size = new Size(416, 87);
            panel5.TabIndex = 2;
            // 
            // btnRightDir
            // 
            btnRightDir.Location = new Point(329, 29);
            btnRightDir.Name = "btnRightDir";
            btnRightDir.Size = new Size(83, 29);
            btnRightDir.TabIndex = 4;
            btnRightDir.Text = "폴더선택";
            btnRightDir.UseVisualStyleBackColor = true;
            // 
            // txtRightDir
            // 
            txtRightDir.Location = new Point(13, 29);
            txtRightDir.Name = "txtRightDir";
            txtRightDir.Size = new Size(310, 27);
            txtRightDir.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnCopyFromRight);
            panel4.Location = new Point(5, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(416, 87);
            panel4.TabIndex = 1;
            // 
            // btnCopyFromRight
            // 
            btnCopyFromRight.BackColor = SystemColors.Desktop;
            btnCopyFromRight.Location = new Point(13, 19);
            btnCopyFromRight.Name = "btnCopyFromRight";
            btnCopyFromRight.Size = new Size(83, 29);
            btnCopyFromRight.TabIndex = 3;
            btnCopyFromRight.Text = "<<<";
            btnCopyFromRight.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(829, 455);
            Controls.Add(splitContainer1);
            this.Name = "Form1";
            Text = "File Compare v1.0";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel8.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label lblAppName;
        private Panel panel8;
        private Panel panel5;
        private Panel panel4;
        private Button btnLeftDir;
        private TextBox txtLeftDir;
        private ListView lvwLeftDir;
        private Button btnCopyFromLeft;
        private ListView lvwRightDir;
        private Button btnRightDir;
        private TextBox txtRightDir;
        private Button btnCopyFromRight;
        private ColumnHeader Mom;
        private ColumnHeader Date;
        private ColumnHeader Ｎａｍｅ;
        private ColumnHeader Ｍｏｍ;
        private ColumnHeader Ｄａｔｅ;
    }
}
