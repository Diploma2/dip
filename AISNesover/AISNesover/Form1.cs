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
        public static int qq;
        // в строке подключения вместо Admin нужно nGadget
        public static String connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\nGadget\Documents\GitHub\dip\AISNesover\AISNesover\Database1.mdf;Integrated Security=True"; 

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            FormClosed += new FormClosedEventHandler(Form1_FormClosed);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            _sqlWork.FillDataGridViewByQuery(dataGridView1, "SELECT IdMinor,Surname, Name, Patronymic, Sex, Birthday,PlaceBirth,Location,Registration,Education,SurnameMother,NameMother,PatronymicMother,SurnameFather,NameFather,PatronymicFather,Status,Source,Article,Cause,DateDeregistration,BasisOfPuttingOnRecord,Number,DateDecision,Health,Dependency,DateOffense,ParticipantsOffense,ArticleOffense,TypePunishment,LivingConditions,FinStatus,FamilyAddress,SignsFamily,CrimeScene,DateRegistration,AddressOffense,TypeCrime FROM worksheet");
            dataGridView1.Columns[1].HeaderText="Фамилия";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Отчество";
            dataGridView1.Columns[4].HeaderText = "Пол";
            dataGridView1.Columns[5].HeaderText = "Дата рождения";
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[6].Visible = false;
            this.dataGridView1.Columns[7].Visible = false;
            this.dataGridView1.Columns[8].Visible = false;
            this.dataGridView1.Columns[9].Visible = false;
            this.dataGridView1.Columns[10].Visible = false;
            this.dataGridView1.Columns[11].Visible = false;
            this.dataGridView1.Columns[12].Visible = false;
            this.dataGridView1.Columns[13].Visible = false;
            this.dataGridView1.Columns[14].Visible = false;
            this.dataGridView1.Columns[15].Visible = false;
            this.dataGridView1.Columns[16].Visible = false;
            this.dataGridView1.Columns[17].Visible = false;
            this.dataGridView1.Columns[18].Visible = false;
            this.dataGridView1.Columns[19].Visible = false;
            this.dataGridView1.Columns[20].Visible = false;
            this.dataGridView1.Columns[21].Visible = false;
            this.dataGridView1.Columns[22].Visible = false;
            this.dataGridView1.Columns[23].Visible = false;
            this.dataGridView1.Columns[24].Visible = false;
            this.dataGridView1.Columns[25].Visible = false;
            this.dataGridView1.Columns[26].Visible = false;
            this.dataGridView1.Columns[27].Visible = false;
            this.dataGridView1.Columns[28].Visible = false;
            this.dataGridView1.Columns[29].Visible = false;
            this.dataGridView1.Columns[30].Visible = false;
            this.dataGridView1.Columns[31].Visible = false;
            this.dataGridView1.Columns[32].Visible = false;
            this.dataGridView1.Columns[33].Visible = false;
            this.dataGridView1.Columns[34].Visible = false;
            this.dataGridView1.Columns[35].Visible = false;
            this.dataGridView1.Columns[36].Visible = false;
            this.dataGridView1.Columns[37].Visible = false;
            this.dataGridView1.Columns[38].Visible = false;
            this.dataGridView1.Columns[39].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddNes addNes = new AddNes();
            addNes.Show(this);
        }

        public void Refresher()
        {
            _sqlWork.FillDataGridViewByQuery(dataGridView1, "SELECT IdMinor,Surname, Name, Patronymic, Sex, Birthday,PlaceBirth,Location,Registration,Education,SurnameMother,NameMother,PatronymicMother,SurnameFather,NameFather,PatronymicFather,Status,Source,Article,Cause,DateDeregistration,BasisOfPuttingOnRecord,Number,DateDecision,Health,Dependency,DateOffense,ParticipantsOffense,ArticleOffense,TypePunishment,LivingConditions,FinStatus,FamilyAddress,SignsFamily,CrimeScene,DateRegistration,AddressOffense,TypeCrime FROM worksheet");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteRow();
            Refresher();
        }

        public void DeleteRow()
        {
            
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Выберите строку для удаления");
            }
            else
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Выберите строку для редактирования");
            }
            else
            {
                this.Hide();
                EditDB edNes = new EditDB();
                edNes.Show(this);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Выберите строку для просмотра");
            }
            else
            {
                this.Hide();
                LookDB lookNes = new LookDB();
                lookNes.Show(this);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Искать по фамилии")
            {
                _sqlWork.FillDataGridViewByQuery(dataGridView1, "SELECT * FROM worksheet WHERE Surname LIKE '" + textBox1.Text + "%'");
            }
            if (comboBox1.Text == "Искать по имени")
            {
                _sqlWork.FillDataGridViewByQuery(dataGridView1, "SELECT * FROM worksheet WHERE Name LIKE '" + textBox1.Text + "%'");
            }
            if (comboBox1.Text == "Искать по отчеству")
            {
                _sqlWork.FillDataGridViewByQuery(dataGridView1, "SELECT * FROM worksheet WHERE Patronymic LIKE '" + textBox1.Text + "%'");
            }
        }
    }
}
