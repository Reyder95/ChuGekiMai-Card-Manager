namespace ChuGekiMai_Card_Manager
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
            this.cardName = new System.Windows.Forms.Label();
            this.cardList = new System.Windows.Forms.ComboBox();
            this.cardSelect = new System.Windows.Forms.Button();
            this.cardDelete = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.cardAdd = new System.Windows.Forms.Button();
            this.generateCard = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.revertButton = new System.Windows.Forms.Button();
            this.inputCardName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cardName
            // 
            this.cardName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cardName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardName.Location = new System.Drawing.Point(28, 9);
            this.cardName.Name = "cardName";
            this.cardName.Size = new System.Drawing.Size(404, 40);
            this.cardName.TabIndex = 0;
            this.cardName.Text = "No Card Inserted";
            this.cardName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardList
            // 
            this.cardList.FormattingEnabled = true;
            this.cardList.Location = new System.Drawing.Point(28, 64);
            this.cardList.Name = "cardList";
            this.cardList.Size = new System.Drawing.Size(404, 21);
            this.cardList.TabIndex = 1;
            // 
            // cardSelect
            // 
            this.cardSelect.Location = new System.Drawing.Point(357, 91);
            this.cardSelect.Name = "cardSelect";
            this.cardSelect.Size = new System.Drawing.Size(75, 33);
            this.cardSelect.TabIndex = 2;
            this.cardSelect.Text = "Select";
            this.cardSelect.UseVisualStyleBackColor = true;
            this.cardSelect.Click += new System.EventHandler(this.cardSelect_Click);
            // 
            // cardDelete
            // 
            this.cardDelete.Location = new System.Drawing.Point(276, 91);
            this.cardDelete.Name = "cardDelete";
            this.cardDelete.Size = new System.Drawing.Size(75, 33);
            this.cardDelete.TabIndex = 3;
            this.cardDelete.Text = "Delete";
            this.cardDelete.UseVisualStyleBackColor = true;
            this.cardDelete.Click += new System.EventHandler(this.cardDelete_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(356, 210);
            this.textBox5.MaxLength = 4;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(76, 20);
            this.textBox5.TabIndex = 8;
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.AcceptsTab = true;
            this.textBox2.Location = new System.Drawing.Point(28, 210);
            this.textBox2.MaxLength = 4;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(76, 20);
            this.textBox2.TabIndex = 9;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(110, 210);
            this.textBox1.MaxLength = 4;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(76, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(274, 210);
            this.textBox3.MaxLength = 4;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(76, 20);
            this.textBox3.TabIndex = 11;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(192, 210);
            this.textBox4.MaxLength = 4;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(76, 20);
            this.textBox4.TabIndex = 12;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // cardAdd
            // 
            this.cardAdd.Location = new System.Drawing.Point(357, 236);
            this.cardAdd.Name = "cardAdd";
            this.cardAdd.Size = new System.Drawing.Size(75, 31);
            this.cardAdd.TabIndex = 13;
            this.cardAdd.Text = "Add Card";
            this.cardAdd.UseVisualStyleBackColor = true;
            this.cardAdd.Click += new System.EventHandler(this.cardAdd_Click);
            // 
            // generateCard
            // 
            this.generateCard.Location = new System.Drawing.Point(274, 236);
            this.generateCard.Name = "generateCard";
            this.generateCard.Size = new System.Drawing.Size(75, 31);
            this.generateCard.TabIndex = 14;
            this.generateCard.Text = "Generate";
            this.generateCard.UseVisualStyleBackColor = true;
            this.generateCard.Click += new System.EventHandler(this.generateCard_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(357, 343);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 35);
            this.saveButton.TabIndex = 15;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // revertButton
            // 
            this.revertButton.Location = new System.Drawing.Point(274, 343);
            this.revertButton.Name = "revertButton";
            this.revertButton.Size = new System.Drawing.Size(75, 35);
            this.revertButton.TabIndex = 16;
            this.revertButton.Text = "Revert";
            this.revertButton.UseVisualStyleBackColor = true;
            this.revertButton.Click += new System.EventHandler(this.revertButton_Click);
            // 
            // inputCardName
            // 
            this.inputCardName.Location = new System.Drawing.Point(274, 184);
            this.inputCardName.Name = "inputCardName";
            this.inputCardName.Size = new System.Drawing.Size(158, 20);
            this.inputCardName.TabIndex = 17;
            this.inputCardName.TextChanged += new System.EventHandler(this.inputCardName_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 390);
            this.Controls.Add(this.inputCardName);
            this.Controls.Add(this.revertButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.generateCard);
            this.Controls.Add(this.cardAdd);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.cardDelete);
            this.Controls.Add(this.cardSelect);
            this.Controls.Add(this.cardList);
            this.Controls.Add(this.cardName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label cardName;
        private System.Windows.Forms.ComboBox cardList;
        private System.Windows.Forms.Button cardSelect;
        private System.Windows.Forms.Button cardDelete;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button cardAdd;
        private System.Windows.Forms.Button generateCard;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button revertButton;
        private System.Windows.Forms.TextBox inputCardName;
    }
}

