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
    public partial class AddNes : Form
    {
        private sql _sqlWork = new sql();
        public static String connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\nGadget\Documents\GitHub\dip\AISNesover\AISNesover\Database1.mdf;Integrated Security=True"; 

        public AddNes()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            panel2.Visible = false;
            panel3.Visible = false;
            panel8.Visible = false;
            panel10.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((this.textBox1.Text.Length == 0) || (this.textBox2.Text.Length == 0)
                || (this.textBox3.Text.Length == 0) || (this.comboBox1.Text.Length == 0)
                || (this.textBox4.Text.Length == 0) || (this.textBox5.Text.Length == 0)
                || (this.textBox6.Text.Length == 0))
            {
                MessageBox.Show("Данные введены некорректно!\nПроверьте данные",
                    "Error");
            }
            else
            {
                AddNew(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                    textBox4.Text, textBox5.Text, textBox6.Text, textBox31.Text, textBox9.Text, textBox10.Text,textBox8.Text,
                    textBox14.Text,textBox15.Text,textBox13.Text,textBox17.Text,textBox16.Text,textBox18.Text);
            }
        }
        public void AddNew(string surname, string name, string patronymic, string sex, string date,
            string edu, string workPlace, string depend, string health, string birthPlace, string location, string reg,
            string surnameF, string nameF, string patrF, string surnameM, string nameM, string patrM)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open(); //Устанавливаем соединение с базой данных.
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO [dbo].[worksheet] (Surname, Name, Patronymic, Sex, Birthday,Education,WorkPlace,Dependency,Health,PlaceBirth,Location,Registration,SurnameFather,NameFather,PatronymicFather,SurnameMother,NameMother,PatronymicMother) VALUES(N'"
                + surname + "',N'" + name + "',N'" + patronymic + "',N'" + sex + "',N'" + date + "',N'" + edu + "',N'"
                + workPlace + "',N'" + depend + "',N'" + health + "',N'" + birthPlace + "',N'" + location + "',N'" + reg + "',N'"
                + surnameF + "',N'" + nameF + "',N'" + patrF + "',N'" + surnameM + "',N'" + nameM + "',N'" + patrM + "')";
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
            panel3.Visible = false;
            panel8.Visible = false;
            panel10.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel8.Visible = false;
            panel10.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            panel8.Visible = false;
            panel10.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel8.Visible = true;
            panel10.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel8.Visible = false;
            panel10.Visible = true;
        }
    }
}
