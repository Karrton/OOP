namespace LAB_16
{
    partial class DataAddForm
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
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            comboBox2 = new ComboBox();
            textBox3 = new TextBox();
            domainUpDown1 = new DomainUpDown();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            fontDialog1 = new FontDialog();
            button1 = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 28);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(160, 23);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BackColor = Color.WhiteSmoke;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.CausesValidation = false;
            textBox1.ForeColor = SystemColors.InfoText;
            textBox1.ImeMode = ImeMode.NoControl;
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(160, 16);
            textBox1.TabIndex = 2;
            textBox1.Text = "Класс объекта\r\n";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.BackColor = Color.WhiteSmoke;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.CausesValidation = false;
            textBox2.ForeColor = SystemColors.InfoText;
            textBox2.ImeMode = ImeMode.NoControl;
            textBox2.Location = new Point(12, 57);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(160, 16);
            textBox2.TabIndex = 3;
            textBox2.Text = "Предмет";
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(12, 74);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(160, 23);
            comboBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox3.BackColor = Color.WhiteSmoke;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.CausesValidation = false;
            textBox3.ForeColor = SystemColors.InfoText;
            textBox3.ImeMode = ImeMode.NoControl;
            textBox3.Location = new Point(12, 103);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(160, 16);
            textBox3.TabIndex = 5;
            textBox3.Text = "Балл\r\n";
            // 
            // domainUpDown1
            // 
            domainUpDown1.Location = new Point(12, 120);
            domainUpDown1.Name = "domainUpDown1";
            domainUpDown1.Size = new Size(160, 23);
            domainUpDown1.TabIndex = 6;
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox4.BackColor = Color.WhiteSmoke;
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.CausesValidation = false;
            textBox4.ForeColor = SystemColors.InfoText;
            textBox4.ImeMode = ImeMode.NoControl;
            textBox4.Location = new Point(12, 200);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(47, 16);
            textBox4.TabIndex = 7;
            textBox4.Text = "Оценка";
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox5.BackColor = SystemColors.HighlightText;
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.CausesValidation = false;
            textBox5.Font = new Font("Segoe UI", 12F);
            textBox5.ForeColor = SystemColors.InfoText;
            textBox5.ImeMode = ImeMode.NoControl;
            textBox5.Location = new Point(65, 197);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(107, 22);
            textBox5.TabIndex = 8;
            textBox5.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            textBox6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox6.BackColor = Color.WhiteSmoke;
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.CausesValidation = false;
            textBox6.ForeColor = SystemColors.InfoText;
            textBox6.ImeMode = ImeMode.NoControl;
            textBox6.Location = new Point(12, 149);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(160, 16);
            textBox6.TabIndex = 9;
            textBox6.Text = "Имя";
            // 
            // textBox7
            // 
            textBox7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox7.BackColor = SystemColors.HighlightText;
            textBox7.BorderStyle = BorderStyle.None;
            textBox7.CausesValidation = false;
            textBox7.Font = new Font("Segoe UI", 13F);
            textBox7.ForeColor = SystemColors.InfoText;
            textBox7.ImeMode = ImeMode.NoControl;
            textBox7.Location = new Point(12, 168);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(160, 24);
            textBox7.TabIndex = 10;
            textBox7.TextAlign = HorizontalAlignment.Center;
            textBox7.TextChanged += textBox7_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(12, 225);
            button1.Name = "button1";
            button1.Size = new Size(160, 23);
            button1.TabIndex = 11;
            button1.Text = "Добавить!";
            button1.UseVisualStyleBackColor = true;
            // 
            // DataAddForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(184, 261);
            Controls.Add(button1);
            Controls.Add(textBox5);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(domainUpDown1);
            Controls.Add(textBox3);
            Controls.Add(comboBox2);
            Controls.Add(textBox2);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(textBox4);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "DataAddForm";
            Text = "Добавление";
            TransparencyKey = SystemColors.ButtonHighlight;
            WindowState = FormWindowState.Minimized;
            Load += DataAddForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private ComboBox comboBox2;
        private TextBox textBox3;
        private DomainUpDown domainUpDown1;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private FontDialog fontDialog1;
        private Button button1;
    }
}