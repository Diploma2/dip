using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace AISNesover
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            FormClosed += new FormClosedEventHandler(Form2_FormClosed);
            textBox1.UseSystemPasswordChar = true;
            textBox2.UseSystemPasswordChar = true;
            textBox3.UseSystemPasswordChar = true;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Auth frm = (Auth)this.Owner;
            frm.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\nGadget\Documents\GitHub\dip\AISNesover\AISNesover\auth.txt";
            string[] Line;
            Line = File.ReadAllLines(path);
            if ((this.textBox1.Text.Length != 0) & (this.textBox2.Text.Length != 0) & (this.textBox3.Text.Length != 0))
            {
                if (GetMD5(textBox1.Text) == Line[1])
                {

                    if (textBox2.Text == textBox3.Text)
                    {
                        Line[1] = GetMD5(textBox2.Text);
                        File.WriteAllLines(path, Line);
                        MessageBox.Show("Пароль успешно сменен");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Новые пароли не совпадают");
                    }
                }
                else
                {
                    MessageBox.Show("Введен некорректный старый пароль");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
