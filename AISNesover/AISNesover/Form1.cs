using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AISNesover
{
    public partial class Form1 : Form
    {
        private sql _sqlWork = new sql();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.worksheet' table. You can move, or remove it, as needed.
            this.worksheetTableAdapter.Fill(this.dataSet1.worksheet);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNes addNes = new AddNes();
            addNes.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _sqlWork.FillDataGridViewByQuery(dataGridView1, "SELECT Surname, Name, Patronymic, Sex, Birthday FROM worksheet");
        }
    }
}
