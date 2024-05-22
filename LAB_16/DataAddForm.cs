using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_16
{
    public partial class DataAddForm : Form
    {
        public DataAddForm()
        {
            InitializeComponent();
        }

        private void DataAddForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Anchor = AnchorStyles.Left;
            textBox1.ReadOnly = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Anchor = AnchorStyles.Left;
            textBox2.ReadOnly = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox3.Anchor = AnchorStyles.Left;
            textBox3.ReadOnly = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.Anchor = AnchorStyles.Left;
            textBox4.ReadOnly = true;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            textBox5.Anchor = AnchorStyles.Left;
            textBox5.Multiline = true;
            textBox5.AcceptsTab = false;
        }
    }
}
