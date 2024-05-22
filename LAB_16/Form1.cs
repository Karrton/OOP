using LabLibrary;
using Microsoft.VisualBasic;

namespace LAB_16
{
    public partial class Form1 : Form
    {
        Controller controller;

        public Form1()
        {
            controller = new Controller();
            InitializeComponent();
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

            label1.Visible = true;
            dataSelectView.Visible = false;
            dataSelectView.ReadOnly = true;
            dataSelectView.AutoGenerateColumns = false;
            dataSelectView.AllowUserToAddRows = false;
            dataSelectView.AllowUserToDeleteRows = false;

            updateView();
        }

        public void updateView()
        {
            label1.Visible = true;
            dataSelectView.Visible = false;
            label1.Text = "Выполните запрос для отображения.";
            if (controller.CollectionExists())
            {
                dataGridView1.Visible = false;
                Information.Visible = true;
            }
            else
            {
                Information.Visible = false;
                dataGridView1.Visible = true;
                dataGridView1.Rows.Clear();
                foreach (var item in controller.Get())
                    dataGridView1.Rows.Add(item.ToString());
            }
        }

        private void adding_Click(object sender, EventArgs e)
        {
            DataAddForm dataAddForm = new DataAddForm(controller, this);
            dataAddForm.ShowDialog();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {

                saveFileDialog.Filter = "JSON files (*.json)|*.json|XML files (*.xml)|*.xml|Binary files (*.bin)|*.bin|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (saveFileDialog.FilterIndex == 1)
                            controller.SaveToJson(saveFileDialog.FileName);
                        else if (saveFileDialog.FilterIndex == 2)
                            controller.SaveToXml(saveFileDialog.FileName);
                        else if (saveFileDialog.FilterIndex == 3)
                            controller.SaveToBinary(saveFileDialog.FileName);
                        else
                        {
                            MessageBox.Show("Выберите подходящий файл для сериализации.");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}");
                    }
                }
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json|XML files (*.xml)|*.xml|Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            openFileDialog.Title = "Select XML File for Deserialization";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string extension = openFileDialog.FileName.Substring(Math.Max(0, openFileDialog.FileName.Length - 3));
                    if (extension == "son" || (openFileDialog.FilterIndex == 1))
                        controller.LoadFromJson(openFileDialog.FileName);
                    else if (extension == "xml" || (openFileDialog.FilterIndex == 2))
                        controller.LoadFromXml(openFileDialog.FileName);
                    else if (extension == "bin" || (openFileDialog.FilterIndex == 3))
                        controller.LoadFromBinary(openFileDialog.FileName);
                    else
                    {
                        MessageBox.Show("Выберите тип десериализации.");
                        return;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show($"Ошибка при открытии файла. Проверьте расширение или используйте другой файл.");
                }
            }
            updateView();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (controller.CollectionExists())
            {
                MessageBox.Show("Невозможно удалить элемент! Коллекция пустая.");
                return;
            }
            DataGridViewSelectedRowCollection selectedRows = dataGridView1.SelectedRows;
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Выделите строку в таблице для удаления.");
                return;
            }
            List<Challenge> listForDelete = new List<Challenge>(selectedRows.Count);
            foreach (DataGridViewRow row in selectedRows)
            {
                listForDelete.Add(controller.ElementAt(row.Index));
            }
            controller.DeleteElements(listForDelete);
            updateView();
        }

        private void generate_Click(object sender, EventArgs e)
        {
            DataGenerateForm dataGenerateForm = new DataGenerateForm(controller);
            dataGenerateForm.ShowDialog();
            updateView();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                dataGridView1.Rows[e.RowIndex].Selected = true;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                dataGridView1.Rows[e.RowIndex].Selected = true;

            Challenge beforeAnimal = controller.ElementAt(e.RowIndex);
            DataEditForm editForm = new DataEditForm(beforeAnimal, controller);
            editForm.ShowDialog();
            updateView();
        }

        private void buttonSelect1_Click(object sender, EventArgs e)
        {
            if (controller.CollectionExists())
            {
                label1.Visible = true;
                dataSelectView.Visible = false;
                label1.Text = "Коллеция пустая, невозможно выполнить запрос.";
                return;
            }
            dataSelectView.Rows.Clear();
            label1.Visible = false;
            dataSelectView.Visible = true;
            foreach (var item in controller.)
                dataSelectView.Rows.Add(item.ToString());
            if (dataSelectView.Rows.Count == 0)
            {
                label1.Visible = true;
                dataSelectView.Visible = false;
                label1.Text = "Нет таких данных.";
            }

        }

        private void buttonSelect2_Click(object sender, EventArgs e)
        {
            if (controller.CollectionExists())
            {
                label1.Visible = true;
                dataSelectView.Visible = false;
                label1.Text = "Коллеция пустая, невозможно выполнить запрос.";
                return;
            }
            dataSelectView.Rows.Clear();
            label1.Visible = false;
            dataSelectView.Visible = true;
            foreach (var item in controller.FilterByType("Math"))
                dataSelectView.Rows.Add(item.ToString());
            if (dataSelectView.Rows.Count == 0)
            {
                label1.Visible = true;
                dataSelectView.Visible = false;
                label1.Text = "Невозможно отсортировать.";
            }
        }

        private void buttonSelect3_Click(object sender, EventArgs e)
        {
            if (controller.CollectionExists())
            {
                label1.Visible = true;
                dataSelectView.Visible = false;
                label1.Text = "Коллеция пустая, невозможно выполнить запрос.";
                return;
            }
            int olderAge = (int)numericUpDownAge.Value;
            dataSelectView.Rows.Clear();
            label1.Visible = false;
            dataSelectView.Visible = true;
            foreach (var item in controller.OlderThen(olderAge))
                dataSelectView.Rows.Add(item.ToString());
            if (dataSelectView.Rows.Count == 0)
            {
                label1.Visible = true;
                dataSelectView.Visible = false;
                label1.Text = $"Нет животных старше {olderAge} лет.";
            }
        }
    }
}
