using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Congés
{
    public partial class Demande_Congé : Form
    {
        Demande_Conge ClassDemande = new Demande_Conge();
        DemandeEntities demande = new DemandeEntities();
        DemandeConge DC = new DemandeConge();
        public Demande_Congé()
        {
            InitializeComponent();
            string[] s = new string[] { "Administratif", "Annulé", "Exceptionnel" };
            comCon.Items.AddRange(s);
        }

        private void Demande_Congé_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (ClassDemande.Ajoute_Demande(int.Parse(textBox1.Text),textBox2.Text,textBox3.Text, comCon.SelectedItem.ToString(), DateTime.Parse(dateTimePicker1.Text), int.Parse(textBox5.Text),textBox4.Text) == true)
            {
                MessageBox.Show("Demande Envoie");
            }
            else
            {
                MessageBox.Show(" Votre Demande est déja Envoie");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LogIn f = new LogIn();
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
    }
}
