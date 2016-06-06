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
    public partial class LookDB : Form
    {
        private sql _sqlWork = new sql();
        public static int qq;
        // в строке подключения вместо Admin нужно nGadget
        public static String connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\nGadget\Documents\GitHub\dip\AISNesover\AISNesover\Database1.mdf;Integrated Security=True"; 

        public LookDB()
        {
            InitializeComponent();
            FormClosed += new FormClosedEventHandler(LookDB_FormClosed);
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

        private void LookDB_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 frm = (Form1)this.Owner;
            frm.Refresher();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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

        private void LookDB_Load(object sender, EventArgs e)
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

                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                comboBox1.Enabled = false;
                dateTimePicker1.Enabled = false;
                textBox4.Enabled = false;
                textBox6.Enabled = false;
                comboBox3.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                textBox8.Enabled = false;
                textBox14.Enabled = false;
                textBox15.Enabled = false;
                textBox13.Enabled = false;
                textBox17.Enabled = false;
                textBox16.Enabled = false;
                textBox18.Enabled = false;
                textBox7.Enabled = false;
                comboBox4.Enabled = false;
                textBox12.Enabled = false;
                comboBox5.Enabled = false;
                comboBox2.Enabled = false;
                textBox21.Enabled = false;
                textBox22.Enabled = false;
                textBox23.Enabled = false;
                dateTimePicker2.Enabled = false;
                dateTimePicker3.Enabled = false;
                textBox20.Enabled = false;
                textBox24.Enabled = false;
                dateTimePicker4.Enabled = false;
                textBox25.Enabled = false;
                dateTimePicker5.Enabled = false;
                textBox26.Enabled = false;
                textBox27.Enabled = false;
                textBox28.Enabled = false;
                textBox29.Enabled = false;
                textBox30.Enabled = false;
            }
        }
    }
}
