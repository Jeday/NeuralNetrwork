namespace NeuralNetwork1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.AccuracyCounter = new System.Windows.Forms.TrackBar();
            this.EpochesCounter = new System.Windows.Forms.NumericUpDown();
            this.TrainingSizeCounter = new System.Windows.Forms.NumericUpDown();
            this.HiddenMagCounter = new System.Windows.Forms.NumericUpDown();
            this.HidLayerCounter = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccuracyCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EpochesCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrainingSizeCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HiddenMagCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HidLayerCounter)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(38, 26);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(101, 13);
            label2.TabIndex = 2;
            label2.Text = "Hidden Layer Count";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(23, 51);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(116, 13);
            label3.TabIndex = 3;
            label3.Text = "Hidden Layer Magnifier";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(40, 77);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(99, 13);
            label4.TabIndex = 5;
            label4.Text = "Training Batch Size";
            label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(59, 107);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(80, 13);
            label5.TabIndex = 7;
            label5.Text = "Epoches Count";
            label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(23, 132);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(52, 13);
            label6.TabIndex = 9;
            label6.Text = "Accuracy";
            label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(23, 234);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(40, 13);
            label7.TabIndex = 12;
            label7.Text = "Status:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(9, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(479, 505);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(494, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.StatusLabel);
            this.groupBox1.Controls.Add(label7);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.AccuracyCounter);
            this.groupBox1.Controls.Add(label6);
            this.groupBox1.Controls.Add(this.EpochesCounter);
            this.groupBox1.Controls.Add(label5);
            this.groupBox1.Controls.Add(this.TrainingSizeCounter);
            this.groupBox1.Controls.Add(label4);
            this.groupBox1.Controls.Add(this.HiddenMagCounter);
            this.groupBox1.Controls.Add(label3);
            this.groupBox1.Controls.Add(label2);
            this.groupBox1.Controls.Add(this.HidLayerCounter);
            this.groupBox1.Location = new System.Drawing.Point(497, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 267);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Neural Network";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(69, 234);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(38, 13);
            this.StatusLabel.TabIndex = 13;
            this.StatusLabel.Text = "NONE";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(105, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Train";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AccuracyCounter
            // 
            this.AccuracyCounter.Location = new System.Drawing.Point(26, 148);
            this.AccuracyCounter.Maximum = 100;
            this.AccuracyCounter.Name = "AccuracyCounter";
            this.AccuracyCounter.Size = new System.Drawing.Size(245, 45);
            this.AccuracyCounter.TabIndex = 10;
            this.AccuracyCounter.TickFrequency = 10;
            this.AccuracyCounter.Value = 50;
            this.AccuracyCounter.Scroll += new System.EventHandler(this.AccuracyCounter_Scroll);
            // 
            // EpochesCounter
            // 
            this.EpochesCounter.Location = new System.Drawing.Point(168, 100);
            this.EpochesCounter.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.EpochesCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.EpochesCounter.Name = "EpochesCounter";
            this.EpochesCounter.Size = new System.Drawing.Size(120, 20);
            this.EpochesCounter.TabIndex = 8;
            this.EpochesCounter.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.EpochesCounter.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // TrainingSizeCounter
            // 
            this.TrainingSizeCounter.Location = new System.Drawing.Point(168, 70);
            this.TrainingSizeCounter.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.TrainingSizeCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TrainingSizeCounter.Name = "TrainingSizeCounter";
            this.TrainingSizeCounter.Size = new System.Drawing.Size(120, 20);
            this.TrainingSizeCounter.TabIndex = 6;
            this.TrainingSizeCounter.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.TrainingSizeCounter.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // HiddenMagCounter
            // 
            this.HiddenMagCounter.Location = new System.Drawing.Point(168, 44);
            this.HiddenMagCounter.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.HiddenMagCounter.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.HiddenMagCounter.Name = "HiddenMagCounter";
            this.HiddenMagCounter.Size = new System.Drawing.Size(120, 20);
            this.HiddenMagCounter.TabIndex = 4;
            this.HiddenMagCounter.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // HidLayerCounter
            // 
            this.HidLayerCounter.Location = new System.Drawing.Point(168, 19);
            this.HidLayerCounter.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.HidLayerCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HidLayerCounter.Name = "HidLayerCounter";
            this.HidLayerCounter.Size = new System.Drawing.Size(120, 20);
            this.HidLayerCounter.TabIndex = 0;
            this.HidLayerCounter.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(497, 329);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(107, 110);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(63, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Triangle";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(7, 43);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(74, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Rectangle";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(7, 66);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(51, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Circle";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 89);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(40, 17);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Text = "Sin";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton5);
            this.groupBox3.Controls.Add(this.radioButton6);
            this.groupBox3.Location = new System.Drawing.Point(610, 329);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(181, 83);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(6, 43);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(58, 17);
            this.radioButton5.TabIndex = 5;
            this.radioButton5.Text = "Predict";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Checked = true;
            this.radioButton6.Location = new System.Drawing.Point(6, 20);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(49, 17);
            this.radioButton6.TabIndex = 4;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Train";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(642, 426);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "label8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(610, 426);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 52);
            this.label9.TabIndex = 7;
            this.label9.Text = "0:\r\n1:\r\n2:\r\n3:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 570);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccuracyCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EpochesCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrainingSizeCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HiddenMagCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HidLayerCounter)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown HidLayerCounter;
        private System.Windows.Forms.NumericUpDown HiddenMagCounter;
        private System.Windows.Forms.NumericUpDown TrainingSizeCounter;
        private System.Windows.Forms.NumericUpDown EpochesCounter;
        private System.Windows.Forms.TrackBar AccuracyCounter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

