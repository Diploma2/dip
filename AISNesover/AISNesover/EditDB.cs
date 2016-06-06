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
    public partial class EditDB : Form
    {
        private sql _sqlWork = new sql();
        public static int qq;
        // в строке подключения вместо Admin нужно nGadget
        public static String connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\nGadget\Documents\GitHub\dip\AISNesover\AISNesover\Database1.mdf;Integrated Security=True"; 

        public EditDB()
        {
            InitializeComponent();
            FormClosed += new FormClosedEventHandler(EditDB_FormClosed);
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

        private void EditDB_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 frm = (Form1)this.Owner;
            frm.Refresher();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateTab(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                textBox4.Text, textBox6.Text, comboBox3.Text, textBox9.Text, textBox10.Text, textBox8.Text, textBox14.Text, 
                textBox15.Text, textBox13.Text, textBox17.Text, textBox16.Text, textBox18.Text, textBox7.Text,
                comboBox4.Text, textBox12.Text, comboBox5.Text, comboBox2.Text, textBox21.Text, textBox22.Text,
                textBox23.Text, dateTimePicker2.Value.ToString("yyyy-MM-dd"), dateTimePicker3.Value.ToString("yyyy-MM-dd"), textBox20.Text, textBox24.Text,
                dateTimePicker4.Value.ToString("yyyy-MM-dd"), textBox25.Text, dateTimePicker5.Value.ToString("yyyy-MM-dd"), textBox26.Text, textBox27.Text, 
                textBox28.Text, textBox29.Text, textBox30.Text );
            this.Close();
        }

        public void UpdateTab(string surname, string name, string patronymic, string sex, string date,
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
            cmd.CommandText = "UPDATE [dbo].[worksheet] SET Surname=N'" + surname + "',Name=N'" + name + "',Patronymic=N'" + patronymic + "',Sex=N'" + sex + "',Birthday=N'" + date + "',PlaceBirth=N'" + birthPlace + "',Location=N'" + location + "',Registration=N'" + reg + "',Education=N'" + edu + "',SurnameMother=N'" + surnameM + "',NameMother=N'" + nameM + "',PatronymicMother=N'" + patrM + "',SurnameFather=N'" + surnameF + "',NameFather=N'" + nameF + "',PatronymicFather=N'" + patrF + "',Status=N'" + status + "',Source=N'" + source + "',Article=N'" + article + "',Cause=N'" + cause + "',DateDeregistration=N'" + dateDeregistration + "',BasisOfPuttingOnRecord=N'" + basePutting + "',Number=N'" + number + "',DateDecision=N'" + dateDecision + "',Health=N'" + health + "',Dependency=N'" + depend + "',DateOffense=N'" + dateOffense + "',ParticipantsOffense=N'" + participants + "',ArticleOffense=N'" + articleOffense + "',TypePunishment=N'" + punishment + "',LivingConditions=N'" + livCond + "',FinStatus=N'" + finStatus + "',FamilyAddress=N'" + addrFamily + "',SignsFamily=N'" + signFamily + "',CrimeScene=N'" + crimeScene + "',DateRegistration=N'" + dateRegistration + "',AddressOffense=N'" + addrOffense + "',TypeCrime=N'" + typeCrime + "'  WHERE IdMinor='" + qq + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Запись обновлена!", "Редактирование", MessageBoxButtons.OK);
            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel8.Visible = false;
            panel10.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
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

        public void EditDB_Load(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                int row = main.dataGridView1.CurrentRow.Index;
                qq = Convert.ToInt32(main.dataGridView1[0, row].Value.ToString());
                string x1 = main.dataGridView1[1, row].Value.ToString();
                string x2 = main.dataGridView1[2, row].Value.ToString();
                string x3 = main.dataGridView1[3, row].Value.ToString();
                string x4 = main.dataGridView1[4, row].Value.ToString();
                string x5 = main.dataGridView1[5, row].Value.ToString();
                string x6 = main.dataGridView1[6, row].Value.ToString();
                string x7 = main.dataGridView1[7, row].Value.ToString();
                string x8 = main.dataGridView1[8, row].Value.ToString();
                string x9 = main.dataGridView1[9, row].Value.ToString();
                string x10 = main.dataGridView1[10, row].Value.ToString();
                string x11 = main.dataGridView1[11, row].Value.ToString();
                string x12 = main.dataGridView1[12, row].Value.ToString();
                string x13 = main.dataGridView1[13, row].Value.ToString();
                string x14 = main.dataGridView1[14, row].Value.ToString();
                string x15 = main.dataGridView1[15, row].Value.ToString();
                string x16 = main.dataGridView1[16, row].Value.ToString();
                string x17 = main.dataGridView1[17, row].Value.ToString();
                string x18 = main.dataGridView1[18, row].Value.ToString();
                string x19 = main.dataGridView1[19, row].Value.ToString();
                string x20 = main.dataGridView1[20, row].Value.ToString();
                string x21 = main.dataGridView1[21, row].Value.ToString();
                string x22 = main.dataGridView1[22, row].Value.ToString();
                string x23 = main.dataGridView1[23, row].Value.ToString();
                string x24 = main.dataGridView1[24, row].Value.ToString();
                string x25 = main.dataGridView1[25, row].Value.ToString();
                string x26 = main.dataGridView1[26, row].Value.ToString();
                string x27 = main.dataGridView1[27, row].Value.ToString();
                string x28 = main.dataGridView1[28, row].Value.ToString();
                string x29 = main.dataGridView1[29, row].Value.ToString();
                string x30 = main.dataGridView1[30, row].Value.ToString();
                string x31 = main.dataGridView1[31, row].Value.ToString();
                string x32 = main.dataGridView1[32, row].Value.ToString();
                string x33 = main.dataGridView1[33, row].Value.ToString();
                string x34 = main.dataGridView1[34, row].Value.ToString();
                string x35 = main.dataGridView1[35, row].Value.ToString();
                string x36 = main.dataGridView1[36, row].Value.ToString();
                string x37 = main.dataGridView1[37, row].Value.ToString();
                textBox1.Text = x1;
                textBox2.Text = x2;
                textBox3.Text = x3;
                comboBox1.Text = x4;
                dateTimePicker1.Text = x5;
                textBox4.Text = x9;
                textBox6.Text = x25;
                comboBox3.Text = x24;
                textBox9.Text = x6;
                textBox10.Text = x7;
                textBox8.Text = x8;
                textBox14.Text = x13;
                textBox15.Text = x14;
                textBox13.Text = x15;
                textBox17.Text = x10;
                textBox16.Text = x11;
                textBox18.Text = x12;
                textBox7.Text = x30;
                comboBox4.Text = x31;
                textBox12.Text = x32;
                comboBox5.Text = x33;
                comboBox2.Text = x16;
                textBox21.Text = x19;
                textBox22.Text = x17;
                textBox23.Text = x18;
                dateTimePicker2.Text = x35;
                dateTimePicker3.Text = x20;
                textBox20.Text = x21;
                textBox24.Text = x22;
                dateTimePicker4.Text = x23;
                textBox25.Text = x37;
                dateTimePicker5.Text = x26;
                textBox26.Text = x34;
                textBox27.Text = x36;
                textBox28.Text = x27;
                textBox29.Text = x28;
                textBox30.Text = x29;
            }
        }
    }
}
