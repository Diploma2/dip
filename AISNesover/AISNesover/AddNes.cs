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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            AddNew(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd"));
           /* string connStr = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connStr); // создаем подключение
            conn.Open(); // открываем подключение
            SqlCommand cmd = new SqlCommand("Insert Into worksheet ([Surname], [Name], [Patronymic],[Birthday]) Values ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "')", conn); // создаем SQL запрос
            cmd.ExecuteNonQuery(); // выполняем запрос на сервер
            conn.Close(); // закрываем соединение*/
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
    }
}
