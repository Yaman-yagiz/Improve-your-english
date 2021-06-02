using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WordMeaning
{
    public partial class Form1 : Form
    {
        public MySqlConnection sqlCon = new MySqlConnection("Data Source = localhost; User ID = root; Pwd = 12345");
        public MySqlDataReader dr;
        public MySqlCommand cmd;
        public int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        public string AnlamBul(string s)
        {
            MySqlCommand cmd2 = new MySqlCommand("select * from wordtable where word='" + listBox1.SelectedItem.ToString() + "'", sqlCon);
            MySqlDataReader dr2 = cmd2.ExecuteReader();
            dr2.Read();
            s = dr2["meaning1"].ToString() + ", " + dr2["meaning2"].ToString() + ", " + dr2["meaning3"].ToString();
            dr2.Close();
            return s;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LevelCBOX.Items.Add("A1");
            LevelCBOX.Items.Add("A2");
            LevelCBOX.Items.Add("B1");
            LevelCBOX.Items.Add("B2");
            LevelCBOX.Items.Add("C1");
            LevelCBOX.SelectedIndex = 0;
            listBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string meaning = MeaningTBOX.Text.TrimStart(' ').ToLower();
            if (string.IsNullOrEmpty(meaning) == false)
            {
                Regex r = new Regex(@"\s+");
                meaning = r.Replace(meaning, @" ");
                sqlCon.Open();
                cmd = new MySqlCommand("Use WordMeaningDB", sqlCon);
                dr = cmd.ExecuteReader();
                dr.Close();
                cmd = new MySqlCommand("SELECT * FROM WordTable where word='" + listBox1.SelectedItem.ToString() + "' AND meaning1='" + meaning + "' OR meaning2='" + meaning + "' OR meaning3='" + meaning + "'", sqlCon);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    score++;
                    MessageBox.Show("Tebrikler Doğru Cevap"); 
                }
                else
                {
                    dr.Close();
                    string a = "";
                    a = AnlamBul(a);
                    MessageBox.Show("Yanlış Cevap: " + meaning + "\nDoğru Cevap: " + a);
                }
                sqlCon.Close();
            }
            else MessageBox.Show("Lütfen Bir Cevap Giriniz");
            ScoreLBL.Text = "Doğru Cevap: " + score;
        }

        private void LevelCBOX_SelectedValueChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); 
            sqlCon.Open();
            MySqlCommand cmd = new MySqlCommand("Use WordMeaningDB", sqlCon);
            dr = cmd.ExecuteReader();
            dr.Close();
            cmd = new MySqlCommand("Select * From WordTable Where Level= " + LevelCBOX.SelectedIndex, sqlCon);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr["word"].ToString());
            }
            listBox1.SelectedIndex = 0;
            sqlCon.Close();
        }

        private void TestYapMENU_Click(object sender, EventArgs e)
        {
            Form form = new Form2();
            this.Hide();
            form.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
