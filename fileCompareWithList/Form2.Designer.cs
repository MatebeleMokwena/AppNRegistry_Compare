namespace fileCompareWithList
{
    partial class Form2
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
            btnOpn = new Button();
            listView2 = new ListView();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            lblCurrent = new Label();
            label1 = new Label();
            btnretry = new Button();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnOpn
            // 
            btnOpn.Anchor = AnchorStyles.None;
            btnOpn.Location = new Point(532, 23);
            btnOpn.Name = "btnOpn";
            btnOpn.Size = new Size(94, 29);
            btnOpn.TabIndex = 0;
            btnOpn.Text = "Open";
            btnOpn.UseVisualStyleBackColor = true;
            btnOpn.Click += btnOpn_Click_1;
            // 
            // listView2
            // 
            tableLayoutPanel1.SetColumnSpan(listView2, 2);
            listView2.Dock = DockStyle.Fill;
            listView2.Location = new Point(13, 84);
            listView2.Name = "listView2";
            listView2.Size = new Size(1242, 587);
            listView2.TabIndex = 1;
            listView2.UseCompatibleStateImageBehavior = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.285223F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 87.7147751F));
            tableLayoutPanel1.Controls.Add(listView2, 0, 1);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10, 10, 10, 20);
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.692771F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 89.30723F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 9F));
            tableLayoutPanel1.Size = new Size(1268, 694);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top;
            groupBox1.BackColor = SystemColors.ButtonShadow;
            tableLayoutPanel1.SetColumnSpan(groupBox1, 2);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lblCurrent);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnretry);
            groupBox1.Controls.Add(btnOpn);
            groupBox1.Location = new Point(13, 13);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1242, 59);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.Control;
            label5.Location = new Point(115, 27);
            label5.Name = "label5";
            label5.Size = new Size(50, 20);
            label5.TabIndex = 6;
            label5.Text = "Match";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Red;
            label4.Location = new Point(189, 27);
            label4.Name = "label4";
            label4.Size = new Size(100, 20);
            label4.TabIndex = 5;
            label4.Text = "Do not match";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.DarkGoldenrod;
            label3.Location = new Point(15, 27);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 4;
            label3.Text = "Not Found";
            // 
            // lblCurrent
            // 
            lblCurrent.AutoSize = true;
            lblCurrent.Location = new Point(842, 25);
            lblCurrent.Name = "lblCurrent";
            lblCurrent.Size = new Size(23, 20);
            lblCurrent.TabIndex = 3;
            lblCurrent.Text = "??";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(751, 24);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 2;
            label1.Text = "Current file:";
            // 
            // btnretry
            // 
            btnretry.Location = new Point(1126, 20);
            btnretry.Name = "btnretry";
            btnretry.Size = new Size(94, 29);
            btnretry.TabIndex = 1;
            btnretry.Text = "Recheck";
            btnretry.UseVisualStyleBackColor = true;
            btnretry.Click += btnretry_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1268, 694);
            Controls.Add(tableLayoutPanel1);
            Name = "Form2";
            Text = "Registry Compare";
            Load += Form2_Load;
            tableLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnOpn;
        private ListView listView2;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label lblCurrent;
        private Label label1;
        private Button btnretry;
    }
}