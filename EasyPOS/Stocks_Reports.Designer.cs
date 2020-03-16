namespace EasyPOS
{
    partial class Stocks_Reports
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
            this.buttonPricelist = new System.Windows.Forms.Button();
            this.btnStockCard = new System.Windows.Forms.Button();
            this.btnStockReplenish = new System.Windows.Forms.Button();
            this.dateTimePickerfrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.GenerateStatementBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPricelist
            // 
            this.buttonPricelist.Location = new System.Drawing.Point(24, 12);
            this.buttonPricelist.Name = "buttonPricelist";
            this.buttonPricelist.Size = new System.Drawing.Size(75, 23);
            this.buttonPricelist.TabIndex = 0;
            this.buttonPricelist.Text = "Price List";
            this.buttonPricelist.UseVisualStyleBackColor = true;
            this.buttonPricelist.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnStockCard
            // 
            this.btnStockCard.Location = new System.Drawing.Point(238, 12);
            this.btnStockCard.Name = "btnStockCard";
            this.btnStockCard.Size = new System.Drawing.Size(75, 23);
            this.btnStockCard.TabIndex = 1;
            this.btnStockCard.Text = "Stock Card";
            this.btnStockCard.UseVisualStyleBackColor = true;
            // 
            // btnStockReplenish
            // 
            this.btnStockReplenish.Location = new System.Drawing.Point(105, 12);
            this.btnStockReplenish.Name = "btnStockReplenish";
            this.btnStockReplenish.Size = new System.Drawing.Size(127, 23);
            this.btnStockReplenish.TabIndex = 2;
            this.btnStockReplenish.Text = "Stock Replenishment";
            this.btnStockReplenish.UseVisualStyleBackColor = true;
            this.btnStockReplenish.Click += new System.EventHandler(this.btnStockReplenish_Click);
            // 
            // dateTimePickerfrom
            // 
            this.dateTimePickerfrom.Location = new System.Drawing.Point(105, 77);
            this.dateTimePickerfrom.Name = "dateTimePickerfrom";
            this.dateTimePickerfrom.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerfrom.TabIndex = 3;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(105, 113);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerTo.TabIndex = 4;
            // 
            // GenerateStatementBtn
            // 
            this.GenerateStatementBtn.Location = new System.Drawing.Point(105, 152);
            this.GenerateStatementBtn.Name = "GenerateStatementBtn";
            this.GenerateStatementBtn.Size = new System.Drawing.Size(173, 23);
            this.GenerateStatementBtn.TabIndex = 7;
            this.GenerateStatementBtn.Text = "Generate Statement";
            this.GenerateStatementBtn.UseVisualStyleBackColor = true;
            this.GenerateStatementBtn.Click += new System.EventHandler(this.GenerateStatementBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(70, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(243, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Run Monthly Replenishment ";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Stocks_Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 261);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.GenerateStatementBtn);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.dateTimePickerfrom);
            this.Controls.Add(this.btnStockReplenish);
            this.Controls.Add(this.btnStockCard);
            this.Controls.Add(this.buttonPricelist);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Stocks_Reports";
            this.Text = "Stocks_Reports";
            this.Load += new System.EventHandler(this.Stocks_Reports_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPricelist;
        private System.Windows.Forms.Button btnStockCard;
        private System.Windows.Forms.Button btnStockReplenish;
        private System.Windows.Forms.DateTimePicker dateTimePickerfrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Button GenerateStatementBtn;
        private System.Windows.Forms.Button button2;
    }
}