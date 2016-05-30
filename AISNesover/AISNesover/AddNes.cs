using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using System.Data.SqlClient;

namespace AISNesover
{
    public partial class AddNes : Form
    {
        private sql _sqlWork = new sql();
        public static String connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\nGadget\Documents\GitHub\dip\AISNesover\AISNesover\Database1.mdf;Integrated Security=True"; 

        public AddNes()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            panel2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((this.textBox1.Text.Length == 0) || (this.textBox2.Text.Length == 0)
                || (this.textBox3.Text.Length == 0) || (this.comboBox1.Text.Length == 0))
            {
                MessageBox.Show("Данные введены некорректно!\nПроверьте данные",
                    "Error");
            }
            else
            {
                AddNew(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            }
        }
        public void AddNew(string surname, string name, string patronymic, string sex, string date)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open(); //Устанавливаем соединение с базой данных.
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO [dbo].[worksheet] (Surname, Name, Patronymic, Sex, Birthday) VALUES(N'"
                + surname + "',N'" + name + "',N'" + patronymic + "',N'" + sex + "',N'" + date + "')";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Добавление прошло успешно!", "Добавление прошло успешно", MessageBoxButtons.OK);
            conn.Close();
            cmd.Dispose();
        }

        private void AddNes_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.worksheet". При необходимости она может быть перемещена или удалена.
            this.worksheetTableAdapter.Fill(this.dataSet1.worksheet);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }
    }
}
