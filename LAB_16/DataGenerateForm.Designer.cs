namespace LAB_16
{
    partial class DataGenerateForm
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
            domainUpDown1 = new DomainUpDown();
            comboBox1 = new ComboBox();
            textBox2 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.WhiteSmoke;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(160, 16);
            textBox1.TabIndex = 0;
            textBox1.Text = "Класс объектов";
            // 
            // domainUpDown1
            // 
            domainUpDown1.Location = new Point(12, 74);
            domainUpDown1.Name = "domainUpDown1";
            domainUpDown1.Size = new Size(160, 23);
            domainUpDown1.TabIndex = 1;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 28);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(160, 23);
            comboBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.WhiteSmoke;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Location = new Point(12, 57);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(160, 16);
            textBox2.TabIndex = 3;
            textBox2.Text = "Количество";
            // 
            // button1
            // 
            button1.Location = new Point(12, 103);
            button1.Name = "button1";
            button1.Size = new Size(160, 23);
            button1.TabIndex = 4;
            button1.Text = "Сгенерировать!";
            button1.UseVisualStyleBackColor = true;
            // 
            // DataGenerateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(184, 131);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(comboBox1);
            Controls.Add(domainUpDown1);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "DataGenerateForm";
            Text = "Генерация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private DomainUpDown domainUpDown1;
        private ComboBox comboBox1;
        private TextBox textBox2;
        private Button button1;
    }
}