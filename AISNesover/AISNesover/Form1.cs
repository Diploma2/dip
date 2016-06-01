using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AISNesover
{
    public partial class Form1 : Form
    {
        private sql _sqlWork = new sql();
        // в строке подключения вместо Admin нужно nGadget
        public static String connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\nGadget\Documents\GitHub\dip\AISNesover\AISNesover\Database1.mdf;Integrated Security=True"; 

       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.worksheet' table. You can move, or remove it, as needed.
            _sqlWork.FillDataGridViewByQuery(dataGridView1, "SELECT IdMinor,Surname, Name, Patronymic, Sex, Birthday FROM worksheet");
            this.dataGridView1.Columns[0].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNes addNes = new AddNes();
            addNes.Show();
         //   this.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Refresher();
        }

        public void Refresher()
        {
            _sqlWork.FillDataGridViewByQuery(dataGridView1, "SELECT IdMinor,Surname, Name, Patronymic, Sex, Birthday FROM worksheet");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteRow();
            Refresher();
        }

        public void DeleteRow()
        {
            int row = dataGridView1.CurrentRow.Index;
            DataGridViewRow rows = dataGridView1.CurrentRow;
            string x1 = dataGridView1[0, row].Value.ToString();

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open(); //Устанавливаем соединение с базой данных.
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM [dbo].[worksheet] WHERE IdMinor='" + x1 + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Запись удалена!", "Удаление", MessageBoxButtons.OK);
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
      /*      int row = dataGridView1.CurrentRow.Index;
            qq = Convert.ToInt32(dataGridView1[0, row].Value.ToString());
            string x1 = dataGridView1[1, row].Value.ToString();
            string x2 = dataGridView1[2, row].Value.ToString();
            textBox1.Text = x1;
            textBox2.Text = x2;
            button1.Visible = false;
            button4.Visible = true;
            label5.Visible = true;
           UpdateTab();*/
        }

   /*     public void UpdateTab(string country, string city)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open(); //Устанавливаем соединение с базой данных.
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE [dbo].[Cities] SET Country=N'" + country + "',City=N'" + city + "'  WHERE IdCity='" + qq + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Запись обновлена!", "Редактирование", MessageBoxButtons.OK);
            conn.Close();
        }*/
    }
}
