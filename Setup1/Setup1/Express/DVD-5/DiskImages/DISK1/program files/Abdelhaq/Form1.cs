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
 
    public partial class Form1 : Form
    {
        private Conge C=new Conge();
        private GesEmploye GsE=new GesEmploye();
        private Stock_Conge Stc=new Stock_Conge();
        Gestion_CongesEntities Gsc = new Gestion_CongesEntities();
        public Form1()
        {
            InitializeComponent();
         
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Gestion_Conge f = new Gestion_Conge();
            f.ShowDialog();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Gestion_Employe f = new Gestion_Employe();
            f.ShowDialog();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
         //   f.activateControls();
            f.ShowDialog();
        }

     

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
            Demande_Congé d = new Demande_Congé();
            d.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!panel4.Controls.Contains(User_Expire.User))
            {
                panel4.Controls.Add(User_Expire.User);
                User_Expire.User.Dock = DockStyle.Fill;
               User_Expire.User.BringToFront();
            }
            else
            {
                User_Expire.User.BringToFront();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
           StockConge f = new StockConge();
            f.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            Ajoute_User f = new Ajoute_User();
            f.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!panel4.Controls.Contains(Demande_User.User))
            {
                panel4.Controls.Add(Demande_User.User);
                Demande_User.User.Dock = DockStyle.Fill;
                Demande_User.User.BringToFront();
            }
            else
            {
                Demande_User.User.BringToFront();
            }
        }
    }
}
