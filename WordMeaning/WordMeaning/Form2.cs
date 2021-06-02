using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WordMeaning
{
    public partial class Form2 : Form
    {
        MySqlConnection sqlCon = new MySqlConnection("Data Source = localhost; User ID = root; Pwd = 12345");
        MySqlDataReader dr;
        MySqlCommand cmd;
        int level = 0;
        int skor = 0;
        string[] words;

        public Form2()
        {
            InitializeComponent();
        }
        void leveldon()
        {
            if (level == 0) LevelLBL.Text = "Seviye: A1";
            else if (level == 1) LevelLBL.Text = "Seviye: A2";
            else if (level == 2) LevelLBL.Text = "Seviye: B1";
            else if (level == 3) LevelLBL.Text = "Seviye: B2";
            else if (level == 4) LevelLBL.Text = "Seviye: C1";
        }
        void soru()
        {
            leveldon();
            sqlCon.Open();
            cmd = new MySqlCommand("use wordmeaningdb", sqlCon);
            dr = cmd.ExecuteReader();
            dr.Close();
            cmd = new MySqlCommand("SELECT * FROM wordtable where level=" + level + " order by RAND() limit 1", sqlCon);
            dr = cmd.ExecuteReader();
            dr.Read();
            WordLBL.Text = "Kelime: " + dr["word"].ToString();
            words = new string[3] { dr["meaning1"].ToString(), dr["meaning2"].ToString(), dr["meaning3"].ToString() };
            sqlCon.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            soru();
        }
        private void AnswerBTN_Click(object sender, EventArgs e)
        {       
            if (string.IsNullOrEmpty(textBox1.Text) == false)
            {
                if (textBox1.Text == words[0] || textBox1.Text == words[1] || textBox1.Text == words[2])
                {
                    skor++;
                    if (skor % 10 == 0) level++;
                }
                else { if (skor > 0) skor--; }
                if (skor < 40 && level == 4) level--;
                else if (skor < 30 && level == 3) level--;
                else if (skor < 20 && level == 2) level--;
                else if (skor < 10 && level == 1) level--;
                textBox1.Clear();
                ScoreLBL.Text = "Skor: " + skor;
            }
            soru();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form form = new Form1();
            form.Show();
            this.Dispose();
        }
    }
}
