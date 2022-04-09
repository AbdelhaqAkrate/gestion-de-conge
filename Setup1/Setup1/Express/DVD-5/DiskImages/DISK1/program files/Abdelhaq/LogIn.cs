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
namespace Gestion_Congés
{
    public partial class LogIn : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-P96B5P5\SQLEXPRESS;Initial Catalog=Gestion_Conges;Integrated Security=True");
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        SqlCommand cmdSelect = new SqlCommand();
        DataTable dt = new DataTable();
        public LogIn()
        {
            InitializeComponent();
          
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

 
        private void button1_Click(object sender, EventArgs e)
        {
            //   cmdSelect.CommandText = "select * from Login";
            cmdSelect.CommandText = "select count(*) from Login where UserName='" + textBox1.Text + "' and Pass='" + textBox2.Text + "'";
            cmdSelect.Connection = con;
            da.SelectCommand = cmdSelect;
            da.Fill(dt);
           if (dt.Rows[0][0].ToString() != "0")
            {
                     MessageBox.Show("Welcome !!");
                    this.Close();
                    Demande_Congé d = new Demande_Congé();
                    d.Close();
                    Form1 f = new Form1();
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Password or user is inncorrect !!");
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true && textBox2.PasswordChar=='*')
            {
                textBox2.PasswordChar = '\0';
            }
            else if (checkBox1.Checked == false && textBox2.PasswordChar == '\0')
            {
                textBox2.PasswordChar = '*';
            }
        }
    }
}
