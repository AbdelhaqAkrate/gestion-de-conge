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
    public partial class Gestion_Employe : Form
    {
        Gérer_Employes GEmploye = new Gérer_Employes();
        Gestion_CongesEntities Gsc = new Gestion_CongesEntities();

        public Gestion_Employe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (GEmploye.AjouterEmploye(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text) == true)
            {
                MessageBox.Show("Employe Ajoute Avec Success");
                dataGridView1.DataSource = Gsc.GesEmployes.Select(c => new { Matricule = c.Matricule, Nom = c.Nom, Prenom = c.Prenom }).ToList();
            }
            else
            {
                MessageBox.Show("Employe Déja Existe");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GEmploye.ModifierEmploye(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text);
            dataGridView1.DataSource = Gsc.GesEmployes.Select(c => new { Matricule = c.Matricule, Nom = c.Nom, Prenom = c.Prenom }).ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int MultiSelect = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    MultiSelect++;
                }
            }
            if (MultiSelect == 0)
            {
                MessageBox.Show("Selectionner Employe");
            }
            else
            {
                DialogResult R = MessageBox.Show("veulez Vous vraiment supprimer", "supprimer", MessageBoxButtons.YesNo);
                if (R == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value) == true)
                        {
                            GEmploye.SupprimerEmploye(int.Parse(row.Cells[1].Value.ToString()));
                        }
                    }
                    dataGridView1.DataSource = Gsc.GesEmployes.Select(c => new { Matricule = c.Matricule, Nom = c.Nom, Prenom = c.Prenom }).ToList();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Gestion_Employe_Load(object sender, EventArgs e)
        {
            var com = Gsc.GesEmployes.Select(emp => emp.Matricule).Distinct();
            comboBox2.DataSource = com.ToList();

            GesEmploye Gs = new GesEmploye();
            dataGridView1.DataSource = Gsc.GesEmployes.Select(c => new { Matricule = c.Matricule, Nom = c.Nom, Prenom = c.Prenom }).ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ajoute_User f = new Ajoute_User();
            f.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Gestion_Conge f = new Gestion_Conge();
            f.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Gestion_Employe f = new Gestion_Employe();
            f.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
          //  f.activateControls();
            f.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockConge f = new StockConge();
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int Mat = int.Parse(comboBox2.SelectedItem.ToString());
            dataGridView1.DataSource = Gsc.Stock_Conge.Where(s => s.GesEmploye.Matricule == Mat).Select(c => new
            {
                Matricule = c.GesEmploye.Matricule,
                Nom = c.GesEmploye.Nom,
                Prenom = c.GesEmploye.Prenom,
            }).ToList();
        }
    }
}
