using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace AISNesover
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\nGadget\Documents\GitHub\dip\AISNesover\AISNesover\auth.txt";
            string[] Line;
            Line = File.ReadAllLines(path);
            if (GetMD5(textBox1.Text) == Line[0])
            {
               if (GetMD5(textBox2.Text) == Line[1])
               {
                   this.Hide();
                   Form1 f1 = new Form1();
                   f1.Show();
               }
               else
               {
                   MessageBox.Show("Неверный пароль");
               }
            }
            else
            {
                MessageBox.Show("Неверный логин");
            }
        }

        public string GetMD5(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 1; i < result.Length; i++)
            {
                str.Append(result[i].ToString("x2"));
            }
            return str.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show(this);
        }
    }
}
