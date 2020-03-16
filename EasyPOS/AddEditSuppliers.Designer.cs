namespace EasyPOS
{
    partial class AddEditSuppliers
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnadd = new System.Windows.Forms.Button();
            this.txtscontact = new ExTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtscontactperson = new ExTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(418, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.Location = new System.Drawing.Point(721, 17);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(125, 49);
            this.btnadd.TabIndex = 9;
            this.btnadd.Text = "Add Supplier";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // txtscontact
            // 
            this.txtscontact.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtscontact.Hint = "Enter Supplier contact details";
            this.txtscontact.Location = new System.Drawing.Point(315, 11);
            this.txtscontact.Multiline = true;
            this.txtscontact.Name = "txtscontact";
            this.txtscontact.Size = new System.Drawing.Size(400, 68);
            this.txtscontact.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 113);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(838, 185);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtscontactperson
            // 
            this.txtscontactperson.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtscontactperson.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtscontactperson.Hint = "Enter Contact Person Name";
            this.txtscontactperson.Location = new System.Drawing.Point(8, 12);
            this.txtscontactperson.Name = "txtscontactperson";
            this.txtscontactperson.Size = new System.Drawing.Size(301, 29);
            this.txtscontactperson.TabIndex = 7;
            // 
            // AddEditSuppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 310);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.txtscontact);
            this.Controls.Add(this.txtscontactperson);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AddEditSuppliers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddEditSuppliers";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnadd;
        private ExTextBox txtscontact;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ExTextBox txtscontactperson;
    }
}