namespace LAB_16
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            adding = new Button();
            Save = new Button();
            Load = new Button();
            form1BindingSource = new BindingSource(components);
            dataGridView1 = new DataGridView();
            columnValue = new DataGridViewTextBoxColumn();
            Information = new Label();
            Delete = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            generate = new Button();
            dataSelectView = new DataGridView();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            flowLayoutPanel2 = new FlowLayoutPanel();
            buttonSelect1 = new Button();
            buttonSelect2 = new Button();
            buttonSelect3 = new Button();
            label1 = new Label();
            labelAge = new Label();
            numericUpDownAge = new NumericUpDown();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)form1BindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataSelectView).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAge).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // adding
            // 
            adding.Location = new Point(3, 3);
            adding.Name = "adding";
            adding.Size = new Size(125, 31);
            adding.TabIndex = 0;
            adding.Text = "Добавить";
            adding.UseVisualStyleBackColor = true;
            adding.Click += adding_Click;
            // 
            // Save
            // 
            Save.Location = new Point(3, 114);
            Save.Name = "Save";
            Save.Size = new Size(125, 31);
            Save.TabIndex = 1;
            Save.Text = "Сохранить как...";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // Load
            // 
            Load.Location = new Point(3, 151);
            Load.Name = "Load";
            Load.Size = new Size(125, 31);
            Load.TabIndex = 2;
            Load.Text = "Открыть";
            Load.UseVisualStyleBackColor = true;
            Load.Click += Load_Click;
            // 
            // form1BindingSource
            // 
            form1BindingSource.DataSource = typeof(Form1);
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { columnValue });
            dataGridView1.Location = new Point(143, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(601, 187);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // columnValue
            // 
            columnValue.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            columnValue.HeaderText = "Value";
            columnValue.Name = "columnValue";
            columnValue.ReadOnly = true;
            columnValue.Width = 60;
            // 
            // Information
            // 
            Information.AutoSize = true;
            Information.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Information.Location = new Point(143, 12);
            Information.Name = "Information";
            Information.Size = new Size(296, 21);
            Information.TabIndex = 4;
            Information.Text = "В коллекции отсутствуют элементы.";
            // 
            // Delete
            // 
            Delete.Location = new Point(3, 77);
            Delete.Name = "Delete";
            Delete.Size = new Size(125, 31);
            Delete.TabIndex = 5;
            Delete.Text = "Удалить";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(adding);
            flowLayoutPanel1.Controls.Add(generate);
            flowLayoutPanel1.Controls.Add(Delete);
            flowLayoutPanel1.Controls.Add(Save);
            flowLayoutPanel1.Controls.Add(Load);
            flowLayoutPanel1.Location = new Point(6, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(131, 187);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // generate
            // 
            generate.Location = new Point(3, 40);
            generate.Name = "generate";
            generate.Size = new Size(125, 31);
            generate.TabIndex = 6;
            generate.Text = "Сгенерировать";
            generate.UseVisualStyleBackColor = true;
            generate.Click += generate_Click;
            // 
            // dataSelectView
            // 
            dataSelectView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataSelectView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataSelectView.BackgroundColor = SystemColors.Control;
            dataSelectView.BorderStyle = BorderStyle.None;
            dataSelectView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataSelectView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn2 });
            dataSelectView.Location = new Point(143, 216);
            dataSelectView.Name = "dataSelectView";
            dataSelectView.RowTemplate.Height = 25;
            dataSelectView.Size = new Size(601, 187);
            dataSelectView.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTextBoxColumn2.HeaderText = "Value";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 60;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(buttonSelect1);
            flowLayoutPanel2.Controls.Add(buttonSelect2);
            flowLayoutPanel2.Controls.Add(buttonSelect3);
            flowLayoutPanel2.Location = new Point(6, 216);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(131, 114);
            flowLayoutPanel2.TabIndex = 8;
            // 
            // buttonSelect1
            // 
            buttonSelect1.Location = new Point(3, 3);
            buttonSelect1.Name = "buttonSelect1";
            buttonSelect1.Size = new Size(125, 31);
            buttonSelect1.TabIndex = 7;
            buttonSelect1.Text = "Фильтрация";
            buttonSelect1.UseVisualStyleBackColor = true;
            buttonSelect1.Click += buttonSelect1_Click;
            // 
            // buttonSelect2
            // 
            buttonSelect2.Location = new Point(3, 40);
            buttonSelect2.Name = "buttonSelect2";
            buttonSelect2.Size = new Size(125, 31);
            buttonSelect2.TabIndex = 9;
            buttonSelect2.Text = "Сортировка";
            buttonSelect2.UseVisualStyleBackColor = true;
            buttonSelect2.Click += buttonSelect2_Click;
            // 
            // buttonSelect3
            // 
            buttonSelect3.Location = new Point(3, 77);
            buttonSelect3.Name = "buttonSelect3";
            buttonSelect3.Size = new Size(125, 31);
            buttonSelect3.TabIndex = 8;
            buttonSelect3.Text = "Старше...";
            buttonSelect3.UseVisualStyleBackColor = true;
            buttonSelect3.Click += buttonSelect3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(143, 216);
            label1.Name = "label1";
            label1.Size = new Size(307, 21);
            label1.TabIndex = 9;
            label1.Text = "Выполните запрос для отображения.";
            // 
            // labelAge
            // 
            labelAge.AutoSize = true;
            labelAge.Location = new Point(3, 0);
            labelAge.Name = "labelAge";
            labelAge.Size = new Size(50, 15);
            labelAge.TabIndex = 0;
            labelAge.Text = "Возраст";
            // 
            // numericUpDownAge
            // 
            numericUpDownAge.Location = new Point(3, 18);
            numericUpDownAge.Name = "numericUpDownAge";
            numericUpDownAge.Size = new Size(125, 23);
            numericUpDownAge.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 77.5F));
            tableLayoutPanel1.Controls.Add(numericUpDownAge, 0, 1);
            tableLayoutPanel1.Controls.Add(labelAge, 0, 0);
            tableLayoutPanel1.Location = new Point(6, 336);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30.6122456F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 69.38776F));
            tableLayoutPanel1.Size = new Size(131, 50);
            tableLayoutPanel1.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(761, 450);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(dataSelectView);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(Information);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)form1BindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataSelectView).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDownAge).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button adding;
        private Button Save;
        private Button Load;
        private ListBox listBox1;
        private BindingSource form1BindingSource;
        private DataGridView dataGridView1;
        private Label Information;
        private Button Delete;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button generate;
        private DataGridView dataSelectView;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button buttonSelect1;
        private Button buttonSelect2;
        private Button buttonSelect3;
        private Label label1;
        private Label labelAge;
        private NumericUpDown numericUpDownAge;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridViewTextBoxColumn columnValue;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}
