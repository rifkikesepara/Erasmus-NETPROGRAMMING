namespace Geometry
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.p1Y = new System.Windows.Forms.NumericUpDown();
            this.p1group = new System.Windows.Forms.GroupBox();
            this.p1X = new System.Windows.Forms.NumericUpDown();
            this.p2group = new System.Windows.Forms.GroupBox();
            this.p2X = new System.Windows.Forms.NumericUpDown();
            this.p2Y = new System.Windows.Forms.NumericUpDown();
            this.p3group = new System.Windows.Forms.GroupBox();
            this.p3X = new System.Windows.Forms.NumericUpDown();
            this.p3Y = new System.Windows.Forms.NumericUpDown();
            this.p4group = new System.Windows.Forms.GroupBox();
            this.p4X = new System.Windows.Forms.NumericUpDown();
            this.p4Y = new System.Windows.Forms.NumericUpDown();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p1Y)).BeginInit();
            this.p1group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p1X)).BeginInit();
            this.p2group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p2X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2Y)).BeginInit();
            this.p3group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p3X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p3Y)).BeginInit();
            this.p4group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p4X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p4Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Geometry.Properties.Resources.sl_072622_51930_13;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(221, 235);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 190);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(284, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(233, 77);
            this.button1.TabIndex = 1;
            this.button1.Text = "Draw";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 58);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ShapeType";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Triangle",
            "Rectangle",
            "Circle",
            "Polygon"});
            this.comboBox1.Location = new System.Drawing.Point(40, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // p1Y
            // 
            this.p1Y.Location = new System.Drawing.Point(28, 44);
            this.p1Y.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.p1Y.Name = "p1Y";
            this.p1Y.Size = new System.Drawing.Size(37, 20);
            this.p1Y.TabIndex = 3;
            // 
            // p1group
            // 
            this.p1group.Controls.Add(this.p1X);
            this.p1group.Controls.Add(this.p1Y);
            this.p1group.Location = new System.Drawing.Point(246, 12);
            this.p1group.Name = "p1group";
            this.p1group.Size = new System.Drawing.Size(92, 79);
            this.p1group.TabIndex = 3;
            this.p1group.TabStop = false;
            this.p1group.Text = "p1";
            // 
            // p1X
            // 
            this.p1X.Location = new System.Drawing.Point(28, 15);
            this.p1X.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.p1X.Name = "p1X";
            this.p1X.Size = new System.Drawing.Size(37, 20);
            this.p1X.TabIndex = 3;
            // 
            // p2group
            // 
            this.p2group.Controls.Add(this.p2X);
            this.p2group.Controls.Add(this.p2Y);
            this.p2group.Location = new System.Drawing.Point(344, 12);
            this.p2group.Name = "p2group";
            this.p2group.Size = new System.Drawing.Size(92, 79);
            this.p2group.TabIndex = 4;
            this.p2group.TabStop = false;
            this.p2group.Text = "p2";
            // 
            // p2X
            // 
            this.p2X.Location = new System.Drawing.Point(28, 15);
            this.p2X.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.p2X.Name = "p2X";
            this.p2X.Size = new System.Drawing.Size(37, 20);
            this.p2X.TabIndex = 3;
            // 
            // p2Y
            // 
            this.p2Y.Location = new System.Drawing.Point(28, 44);
            this.p2Y.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.p2Y.Name = "p2Y";
            this.p2Y.Size = new System.Drawing.Size(37, 20);
            this.p2Y.TabIndex = 3;
            // 
            // p3group
            // 
            this.p3group.Controls.Add(this.p3X);
            this.p3group.Controls.Add(this.p3Y);
            this.p3group.Location = new System.Drawing.Point(442, 12);
            this.p3group.Name = "p3group";
            this.p3group.Size = new System.Drawing.Size(92, 79);
            this.p3group.TabIndex = 5;
            this.p3group.TabStop = false;
            this.p3group.Text = "p3";
            // 
            // p3X
            // 
            this.p3X.Location = new System.Drawing.Point(28, 15);
            this.p3X.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.p3X.Name = "p3X";
            this.p3X.Size = new System.Drawing.Size(37, 20);
            this.p3X.TabIndex = 3;
            // 
            // p3Y
            // 
            this.p3Y.Location = new System.Drawing.Point(28, 44);
            this.p3Y.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.p3Y.Name = "p3Y";
            this.p3Y.Size = new System.Drawing.Size(37, 20);
            this.p3Y.TabIndex = 3;
            // 
            // p4group
            // 
            this.p4group.Controls.Add(this.p4X);
            this.p4group.Controls.Add(this.p4Y);
            this.p4group.Location = new System.Drawing.Point(540, 12);
            this.p4group.Name = "p4group";
            this.p4group.Size = new System.Drawing.Size(92, 79);
            this.p4group.TabIndex = 6;
            this.p4group.TabStop = false;
            this.p4group.Text = "p4";
            // 
            // p4X
            // 
            this.p4X.Location = new System.Drawing.Point(28, 15);
            this.p4X.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.p4X.Name = "p4X";
            this.p4X.Size = new System.Drawing.Size(37, 20);
            this.p4X.TabIndex = 3;
            // 
            // p4Y
            // 
            this.p4Y.Location = new System.Drawing.Point(28, 44);
            this.p4Y.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.p4Y.Name = "p4Y";
            this.p4Y.Size = new System.Drawing.Size(37, 20);
            this.p4Y.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y});
            this.dataGridView1.Location = new System.Drawing.Point(278, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(245, 134);
            this.dataGridView1.TabIndex = 7;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.p4group);
            this.Controls.Add(this.p3group);
            this.Controls.Add(this.p2group);
            this.Controls.Add(this.p1group);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Geometry";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.p1Y)).EndInit();
            this.p1group.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.p1X)).EndInit();
            this.p2group.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.p2X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2Y)).EndInit();
            this.p3group.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.p3X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p3Y)).EndInit();
            this.p4group.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.p4X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p4Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown p1Y;
        private System.Windows.Forms.GroupBox p1group;
        private System.Windows.Forms.NumericUpDown p1X;
        private System.Windows.Forms.GroupBox p2group;
        private System.Windows.Forms.NumericUpDown p2X;
        private System.Windows.Forms.NumericUpDown p2Y;
        private System.Windows.Forms.GroupBox p3group;
        private System.Windows.Forms.NumericUpDown p3X;
        private System.Windows.Forms.NumericUpDown p3Y;
        private System.Windows.Forms.GroupBox p4group;
        private System.Windows.Forms.NumericUpDown p4X;
        private System.Windows.Forms.NumericUpDown p4Y;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
    }
}

