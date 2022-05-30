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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public SqlConnection mycon;
        public Form1()
        {
            InitializeComponent();
            comboBox1.Hide();
            label2.Hide();
            button2.Hide();
            string s = @"Data Source = adclg1; Initial Catalog=319/4 Курьяков; Integrated Security = true";
            mycon = new SqlConnection(s);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmd = "Select name from _users_ where login = @login";
            SqlParameter p1 = new SqlParameter("@login", textBox1.Text);
            SqlCommand cmd1 = new SqlCommand(cmd, mycon);
            cmd1.Parameters.Add(p1);
            mycon.Open();
            string x = cmd1.ExecuteScalar().ToString();
            MessageBox.Show("Привет, " + x, "Хей");
            mycon.Close();
            textBox1.Hide();
            label1.Hide();
            button1.Hide();
            comboBox1.Show();
            label2.Show();
            button2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ass = "select name from _users_ where role = @role";
            SqlDataReader readerl;
            SqlCommand cmd2 = new SqlCommand(ass, mycon);
            SqlParameter p1 = new SqlParameter("@role", comboBox1.Text);
            cmd2.Parameters.Add(p1);
            mycon.Open();
            readerl = cmd2.ExecuteReader();
            listBox1.Items.Clear();
            while (readerl.Read())
            {
                listBox1.Items.Add(readerl[0].ToString());
            }
            mycon.Close();
        }
    }
}
