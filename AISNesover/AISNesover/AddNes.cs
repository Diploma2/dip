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
        public static int qq;
        // в строке подключения вместо Admin нужно nGadget
        public static String connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\nGadget\Documents\GitHub\dip\AISNesover\AISNesover\Database1.mdf;Integrated Security=True"; 

        public AddNes()
        {
            InitializeComponent();
            FormClosed += new FormClosedEventHandler(AddNes_FormClosed);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            panel2.Visible = false;
            panel3.Visible = false;
            panel8.Visible = false;
            panel10.Visible = false;
        }

        private void AddNes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 frm = (Form1)this.Owner;
            frm.Refresher();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((this.textBox1.Text.Length == 0) || (this.textBox2.Text.Length == 0)
                || (this.textBox3.Text.Length == 0) || (this.comboBox1.Text.Length == 0)
                || (this.textBox4.Text.Length == 0) || (this.textBox6.Text.Length == 0))
            {
                MessageBox.Show("Данные введены некорректно!\nПроверьте данные",
                    "Error");
            }
            else
            {
                AddNew(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                    textBox4.Text, textBox6.Text, comboBox3.Text, textBox9.Text, textBox10.Text,textBox8.Text,
                    textBox14.Text,textBox15.Text,textBox13.Text,textBox17.Text,textBox16.Text,textBox18.Text,textBox7.Text,
                    comboBox4.Text,textBox12.Text,comboBox5.Text, comboBox2.Text, textBox21.Text, textBox22.Text, textBox23.Text,
                    dateTimePicker2.Value.ToString("yyyy-MM-dd"), dateTimePicker3.Value.ToString("yyyy-MM-dd"), textBox20.Text, textBox24.Text,
                    dateTimePicker4.Value.ToString("yyyy-MM-dd"), textBox25.Text, dateTimePicker5.Value.ToString("yyyy-MM-dd"), textBox26.Text,
                    textBox27.Text, textBox28.Text, textBox29.Text, textBox30.Text);
            }
            this.Close();
        }

        public void AddNew(string surname, string name, string patronymic, string sex, string date,
            string edu, string depend, string health, string birthPlace, string location, string reg,
            string surnameF, string nameF, string patrF, string surnameM, string nameM, string patrM, string livCond,
            string finStatus, string addrFamily, string signFamily,
            string status, string cause, string source, string article, string dateRegistration, string dateDeregistration,
            string basePutting, string number, string dateDecision, string typeCrime, string dateOffense,
            string crimeScene, string addrOffense, string participants, string articleOffense, string punishment)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open(); //Устанавливаем соединение с базой данных.
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO [dbo].[worksheet] (Surname, Name, Patronymic, Sex, Birthday,Education," + 
                "Dependency,Health,PlaceBirth,Location,Registration,SurnameFather,NameFather,PatronymicFather,SurnameMother," +
                "NameMother,PatronymicMother,LivingConditions,FinStatus, FamilyAddress, SignsFamily, Status, Cause, Source," +
                "Article, DateRegistration, DateDeregistration, BasisOfPuttingOnRecord, Number, DateDecision, TypeCrime, DateOffense," +
                "CrimeScene, AddressOffense, ParticipantsOffense, ArticleOffense, TypePunishment ) VALUES(N'"
                + surname + "',N'" + name + "',N'" + patronymic + "',N'" + sex + "',N'" + date + "',N'" + edu + "',N'" + depend + "',N'" + health + "',N'" + birthPlace + "',N'" + location + "',N'" + reg + "',N'"
                + surnameF + "',N'" + nameF + "',N'" + patrF + "',N'" + surnameM + "',N'" + nameM + "',N'" + patrM + "',N'"
                + livCond + "',N'" + finStatus + "',N'" + addrFamily + "',N'" + signFamily + "',N'"
                + status + "',N'" + cause + "',N'" + source + "',N'" + article + "',N'" + dateRegistration + "',N'" + dateDeregistration + "',N'"
                + basePutting + "',N'" + number + "',N'" + dateDecision + "',N'" + typeCrime + "',N'" + dateOffense + "',N'" + crimeScene + "',N'"
                + addrOffense + "',N'" + participants + "',N'" + articleOffense + "',N'" + punishment + "')";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Добавление прошло успешно!", "Добавление прошло успешно", MessageBoxButtons.OK);
            conn.Close();
            cmd.Dispose();
        }

        private void AddNes_Load(object sender, EventArgs e)
        {
   
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
