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
    public partial class Ajoute_User : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-P96B5P5\SQLEXPRESS;Initial Catalog=Gestion_Conges;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
     
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlCommand cmdSelect = new SqlCommand();
        public Ajoute_User()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
        
            if(textBox2.Text==textBox3.Text)
            {
                try
                {

                    cmdSelect = new SqlCommand("insert into Login values('" + textBox1.Text + "','" + textBox2.Text + "')", con);
                    con.Open();
                    cmdSelect.ExecuteNonQuery();
                    MessageBox.Show("User Ajoute Avec Success", "Ajouté", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { con.Close(); }
               
               
            } 
            else
            {
                MessageBox.Show("Password Incorrect", "Incorrect", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
            }
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
