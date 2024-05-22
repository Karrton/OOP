namespace LAB_16
{
    partial class DataEditForm
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            comboBox1 = new ComboBox();
            domainUpDown1 = new DomainUpDown();
            textBox4 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.WhiteSmoke;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 16);
            textBox1.TabIndex = 0;
            textBox1.Text = "Предмет";
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.WhiteSmoke;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Location = new Point(12, 54);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 16);
            textBox2.TabIndex = 1;
            textBox2.Text = "Балл";
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.WhiteSmoke;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Location = new Point(12, 101);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 16);
            textBox3.TabIndex = 2;
            textBox3.Text = "Имя\r\n";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 30);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(160, 23);
            comboBox1.TabIndex = 3;
            // 
            // domainUpDown1
            // 
            domainUpDown1.Location = new Point(12, 72);
            domainUpDown1.Name = "domainUpDown1";
            domainUpDown1.Size = new Size(160, 23);
            domainUpDown1.TabIndex = 4;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(12, 118);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(160, 23);
            textBox4.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(12, 146);
            button1.Name = "button1";
            button1.Size = new Size(160, 23);
            button1.TabIndex = 6;
            button1.Text = "Изменить!";
            button1.UseVisualStyleBackColor = true;
            // 
            // DataEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(184, 171);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(domainUpDown1);
            Controls.Add(comboBox1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "DataEditForm";
            Text = "Редактирование";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private ComboBox comboBox1;
        private DomainUpDown domainUpDown1;
        private TextBox textBox4;
        private Button button1;
    }
}