namespace fileCompareWithList
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
            groupBox1 = new GroupBox();
            button1 = new Button();
            btnReg = new Button();
            btnOpen = new Button();
            richTextBox1 = new RichTextBox();
            txtDisplay = new TextBox();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(btnReg);
            groupBox1.Controls.Add(btnOpen);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.MaximumSize = new Size(2091, 75);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1440, 75);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Right;
            button1.Location = new Point(1343, 23);
            button1.Name = "button1";
            button1.Size = new Size(94, 49);
            button1.TabIndex = 3;
            button1.Text = "Clear";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnReg
            // 
            btnReg.Dock = DockStyle.Left;
            btnReg.Location = new Point(3, 23);
            btnReg.Name = "btnReg";
            btnReg.Size = new Size(135, 49);
            btnReg.TabIndex = 2;
            btnReg.Text = "Registry";
            btnReg.UseVisualStyleBackColor = true;
            btnReg.Click += btnReg_Click;
            // 
            // btnOpen
            // 
            btnOpen.Anchor = AnchorStyles.Top;
            btnOpen.Location = new Point(623, 20);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(125, 49);
            btnOpen.TabIndex = 1;
            btnOpen.Text = "...";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click_1;
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = DockStyle.Left;
            richTextBox1.Location = new Point(3, 23);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(167, 119);
            richTextBox1.TabIndex = 7;
            richTextBox1.Text = "";
            // 
            // txtDisplay
            // 
            txtDisplay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDisplay.BorderStyle = BorderStyle.None;
            txtDisplay.Location = new Point(176, 23);
            txtDisplay.Multiline = true;
            txtDisplay.Name = "txtDisplay";
            txtDisplay.ScrollBars = ScrollBars.Vertical;
            txtDisplay.Size = new Size(1258, 113);
            txtDisplay.TabIndex = 2;
            // 
            // listView1
            // 
            listView1.BorderStyle = BorderStyle.None;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            listView1.Dock = DockStyle.Fill;
            listView1.Location = new Point(0, 220);
            listView1.Name = "listView1";
            listView1.Size = new Size(1440, 536);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Your file:";
            columnHeader1.Width = 500;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Original";
            columnHeader2.Width = 500;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Status Version";
            columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Status size";
            columnHeader4.Width = 200;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtDisplay);
            groupBox2.Controls.Add(richTextBox1);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 75);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1440, 145);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1440, 756);
            Controls.Add(listView1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "FIle Version Compare";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private TextBox txtDisplay;
        private RichTextBox richTextBox1;
        private Button button1;
        private Button btnReg;
        private Button btnOpen;
        private GroupBox groupBox2;
    }
}
