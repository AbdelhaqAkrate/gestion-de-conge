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
using System.Data.Entity;
namespace Gestion_Congés
{
    public partial class StockConge : Form
    {
        Gestion_CongesEntities Gsc = new Gestion_CongesEntities();
        GesEmploye GsE = new GesEmploye();
        Stock_Conge stc = new Stock_Conge();
        public StockConge()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // int Mat = int.Parse(comboBox2.SelectedItem.ToString());
            //dataGridView1.DataSource = Gsc.Stock_Conge.Where(s => s.GesEmploye.Matricule == Mat).Select(c => new
            //{
            //    Matricule = c.GesEmploye.Matricule,
            //    Nom = c.GesEmploye.Nom,
            //    Prenom = c.GesEmploye.Prenom,
            //    N_Jours = c.NbrJours
            //}).ToList();
        }

        private void StockConge_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Gsc.Stock_Conge.Select(c => new
            {
                Matricule = c.GesEmploye.Matricule,
                Nom = c.GesEmploye.Nom,
                Prenom = c.GesEmploye.Prenom,
                N_Jours = c.NbrJours
            }).ToList();
            var com = Gsc.GesEmployes.Select(emp => emp.Matricule).Distinct();
            comboBox2.DataSource = com.ToList();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            int Mat = int.Parse(comboBox2.SelectedItem.ToString());
            dataGridView1.DataSource = Gsc.Stock_Conge.Where(s => s.GesEmploye.Matricule == Mat).Select(c => new
            {
                Matricule = c.GesEmploye.Matricule,
                Nom = c.GesEmploye.Nom,
                Prenom = c.GesEmploye.Prenom,
                N_Jours = c.NbrJours
            }).ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
       //     f.activateControls();
            f.ShowDialog();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Show();

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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ajoute_User f = new Ajoute_User();
            f.ShowDialog();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
