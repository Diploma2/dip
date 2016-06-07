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
using Word = Microsoft.Office.Interop.Word;
//using Office = Microsoft.Office.Core;
using System.IO;
using System.Reflection;

namespace AISNesover
{
    public partial class LookDB : Form
    {
        private sql _sqlWork = new sql();
        public static int qq;
        // в строке подключения вместо Admin нужно nGadget
        public static String connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Admin\Documents\GitHub\dip\AISNesover\AISNesover\Database1.mdf;Integrated Security=True"; 

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
            SaveDialog.InitialDirectory = Application.StartupPath;
            SaveDialog.Filter = "Microsoft Word 2007-2010 (*.docx)|*.docx";
            SaveDialog.FilterIndex = 3;
            SaveDialog.RestoreDirectory = true;
            SaveDialog.FileName = "Личная карточка (" + textBox1.Text + ' ' + textBox2.Text + ' ' + textBox3.Text + ")";
            if (SaveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // currdirect + "\\temp.docx" - путь к документу-шаблону
                    // В данном случае программа будет искать его в корне программы (папка Debug)
                    string currdirect = Application.StartupPath;
                    File.Copy(currdirect + "\\Личная карточка несовершеннолетнего.docx", SaveDialog.FileName, true);
                    object missing = Missing.Value;
                    Word.Application wordApp = new Word.Application();
                    Word.Document Doc = null;
                    object filename = SaveDialog.FileName;

                    if (File.Exists((string)filename))
                    {
                        object readOnly = false;
                        object isVisible = false;
                        wordApp.Visible = false; // Выключаем видимость ворда
                        Doc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly, ref missing,
                                                      ref missing, ref missing, ref missing, ref missing,
                                                      ref missing, ref missing, ref missing, ref isVisible,
                                                      ref missing, ref missing, ref missing, ref missing);
                        Doc.Activate();
                        // Вот собственно 
                        this.FindAndReplace(wordApp, "[1]", textBox1.Text); 
                        this.FindAndReplace(wordApp, "[2]", textBox2.Text);  
                        this.FindAndReplace(wordApp, "[3]", textBox3.Text);  
                        this.FindAndReplace(wordApp, "[4]", comboBox1.Text);  //cb1
                        this.FindAndReplace(wordApp, "[5]", dateTimePicker1.Value.ToString("dd.MM.yyyy"));  //dtp1
                        this.FindAndReplace(wordApp, "[6]", textBox9.Text);
                        this.FindAndReplace(wordApp, "[7]", textBox10.Text);
                        this.FindAndReplace(wordApp, "[8]", textBox8.Text);
                        this.FindAndReplace(wordApp, "[9]", textBox4.Text); //++
                        this.FindAndReplace(wordApp, "[10]", textBox6.Text);
                        this.FindAndReplace(wordApp, "[11]", comboBox3.Text); //cb3
                        this.FindAndReplace(wordApp, "[12]", textBox14.Text);
                        this.FindAndReplace(wordApp, "[13]", textBox15.Text);
                        this.FindAndReplace(wordApp, "[14]", textBox13.Text);
                        this.FindAndReplace(wordApp, "[15]", textBox17.Text);
                        this.FindAndReplace(wordApp, "[16]", textBox16.Text);
                        this.FindAndReplace(wordApp, "[17]", textBox18.Text);
                        this.FindAndReplace(wordApp, "[18]", textBox7.Text);
                        this.FindAndReplace(wordApp, "[19]", comboBox4.Text); //cb4
                        this.FindAndReplace(wordApp, "[20]", textBox12.Text);
                        this.FindAndReplace(wordApp, "[21]", comboBox5.Text); //cb5
                        this.FindAndReplace(wordApp, "[22]", comboBox2.Text); //cb2
                        this.FindAndReplace(wordApp, "[23]", textBox21.Text);
                        this.FindAndReplace(wordApp, "[24]", textBox22.Text);
                        this.FindAndReplace(wordApp, "[25]", textBox23.Text);
                        this.FindAndReplace(wordApp, "[26]", dateTimePicker2.Value.ToString("dd.MM.yyyy")); //dtp2
                        this.FindAndReplace(wordApp, "[27]", dateTimePicker3.Value.ToString("dd.MM.yyyy")); //dtp3
                        this.FindAndReplace(wordApp, "[28]", textBox20.Text);
                        this.FindAndReplace(wordApp, "[29]", textBox24.Text);
                        this.FindAndReplace(wordApp, "[30]", dateTimePicker4.Value.ToString("dd.MM.yyyy"));  //dtp4
                        this.FindAndReplace(wordApp, "[31]", textBox25.Text);
                        this.FindAndReplace(wordApp, "[32]", dateTimePicker5.Value.ToString("dd.MM.yyyy"));  //dtp5
                        this.FindAndReplace(wordApp, "[33]", textBox26.Text);
                        this.FindAndReplace(wordApp, "[34]", textBox27.Text);
                        this.FindAndReplace(wordApp, "[35]", textBox28.Text);
                        this.FindAndReplace(wordApp, "[36]", textBox29.Text);
                        this.FindAndReplace(wordApp, "[37]", textBox30.Text);
                        Doc.Save();
                    }
                    else
                        MessageBox.Show("Файл не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    wordApp.Visible = true; // И включаем видимость, это для того чтоб не видеть как там все дергается и меняется
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void FindAndReplace(Word.Application wordApp, object findText, object replaceText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            wordApp.Selection.Find.Execute(ref findText, ref matchCase,
                ref matchWholeWord, ref matchWildCards, ref matchSoundsLike,
                ref matchAllWordForms, ref forward, ref wrap, ref format,
                ref replaceText, ref replace, ref matchKashida,
                ref matchDiacritics, ref matchAlefHamza, ref matchControl);
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
