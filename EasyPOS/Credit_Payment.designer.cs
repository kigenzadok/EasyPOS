namespace EasyPOS
{
    partial class Credit_Payment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Credit_Payment));
            this.buttonPay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.balancetxt = new System.Windows.Forms.TextBox();
            this.cmbBusinessname = new System.Windows.Forms.ComboBox();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.Duedate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.datePay = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxChequeNo = new System.Windows.Forms.TextBox();
            this.txtRemaining = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPay
            // 
            this.buttonPay.Location = new System.Drawing.Point(30, 11);
            this.buttonPay.Name = "buttonPay";
            this.buttonPay.Size = new System.Drawing.Size(86, 30);
            this.buttonPay.TabIndex = 0;
            this.buttonPay.Text = "&Pay";
            this.buttonPay.UseVisualStyleBackColor = true;
            this.buttonPay.Click += new System.EventHandler(this.buttonPay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Business Name";
            // 
            // balancetxt
            // 
            this.balancetxt.Enabled = false;
            this.balancetxt.Location = new System.Drawing.Point(356, 70);
            this.balancetxt.Name = "balancetxt";
            this.balancetxt.Size = new System.Drawing.Size(271, 20);
            this.balancetxt.TabIndex = 3;
            this.balancetxt.TextChanged += new System.EventHandler(this.balancetxt_TextChanged);
            // 
            // cmbBusinessname
            // 
            this.cmbBusinessname.FormattingEnabled = true;
            this.cmbBusinessname.Location = new System.Drawing.Point(110, 68);
            this.cmbBusinessname.Name = "cmbBusinessname";
            this.cmbBusinessname.Size = new System.Drawing.Size(185, 21);
            this.cmbBusinessname.TabIndex = 1;
            this.cmbBusinessname.DropDown += new System.EventHandler(this.cmbBusinessname_DropDown);
            this.cmbBusinessname.SelectedIndexChanged += new System.EventHandler(this.cmbBusinessname_SelectedIndexChanged);
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(356, 100);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(85, 20);
            this.textBoxAmount.TabIndex = 12;
            this.textBoxAmount.TextChanged += new System.EventHandler(this.textBoxAmount_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(142, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 30);
            this.button2.TabIndex = 15;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(265, 11);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 30);
            this.button4.TabIndex = 17;
            this.button4.Text = "Exit";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Payment Mode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(304, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Balance";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(307, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Paid";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.buttonPay);
            this.groupBox1.Location = new System.Drawing.Point(110, 167);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 56);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(49, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(144, 25);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Credit Payment";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(8, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 44);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PowderBlue;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.lblTitle);
            this.panel2.Location = new System.Drawing.Point(2, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(625, 54);
            this.panel2.TabIndex = 75;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(110, 103);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(49, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Cash";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click_1);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(190, 103);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(62, 17);
            this.radioButton2.TabIndex = 80;
            this.radioButton2.Text = "Cheque";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // Duedate
            // 
            this.Duedate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Duedate.Location = new System.Drawing.Point(522, 125);
            this.Duedate.Name = "Duedate";
            this.Duedate.Size = new System.Drawing.Size(105, 20);
            this.Duedate.TabIndex = 78;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(467, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 77;
            this.label9.Text = "Due Day";
            // 
            // datePay
            // 
            this.datePay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePay.Location = new System.Drawing.Point(356, 128);
            this.datePay.Name = "datePay";
            this.datePay.Size = new System.Drawing.Size(105, 20);
            this.datePay.TabIndex = 78;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(299, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 76;
            this.label8.Text = "Date Pay";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Cheque No";
            // 
            // textBoxChequeNo
            // 
            this.textBoxChequeNo.Location = new System.Drawing.Point(110, 130);
            this.textBoxChequeNo.Name = "textBoxChequeNo";
            this.textBoxChequeNo.Size = new System.Drawing.Size(185, 20);
            this.textBoxChequeNo.TabIndex = 14;
            // 
            // txtRemaining
            // 
            this.txtRemaining.Enabled = false;
            this.txtRemaining.Location = new System.Drawing.Point(510, 99);
            this.txtRemaining.Name = "txtRemaining";
            this.txtRemaining.Size = new System.Drawing.Size(117, 20);
            this.txtRemaining.TabIndex = 12;
            this.txtRemaining.TextChanged += new System.EventHandler(this.txtRemaining_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(447, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Remaining";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(98, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(167, 38);
            this.groupBox2.TabIndex = 81;
            this.groupBox2.TabStop = false;
            // 
            // Credit_Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 236);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.Duedate);
            this.Controls.Add(this.datePay);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxChequeNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRemaining);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.cmbBusinessname);
            this.Controls.Add(this.balancetxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Credit_Payment";
            this.Text = "Credit_Payment";
            this.Load += new System.EventHandler(this.Credit_Payment_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox balancetxt;
        private System.Windows.Forms.ComboBox cmbBusinessname;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.DateTimePicker Duedate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker datePay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxChequeNo;
        private System.Windows.Forms.TextBox txtRemaining;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}