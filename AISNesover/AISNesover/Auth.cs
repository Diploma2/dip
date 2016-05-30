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
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\nGadget\Documents\GitHub\dip\AISNesover\AISNesover\auth.mdf;Integrated Security=True;Connect Timeout=30;");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Count(*) From LOGIN WHERE USERNAME='" + textBox1.Text + "' and PASSWORD = '" + textBox2.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Form1 f1 = new Form1();
                f1.Show();
            }
            else
            {
                MessageBox.Show("Пожалуйста, проверьте введенные данные");
            }
           
        }
    }
}
