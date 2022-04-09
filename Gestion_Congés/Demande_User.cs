using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Congés
{
   
    public partial class Demande_User : UserControl
    {
        DemandeEntities demande = new DemandeEntities();
        DemandeConge DC = new DemandeConge();
        public Demande_User()
        {
            InitializeComponent();
        }
        public static Demande_User UD;
        public static Demande_User User
        {
            get
            {
                if (UD == null)
                {
                    UD = new Demande_User();
                }
                return UD;
            }
        }
        private void Demande_User_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = demande.DemandeConges.Select(c => new
            {
                Matricule = c.Matricule,
                Nom = c.Nom,
                Prenom = c.Prenom,
                Type_Congé = c.Type_Conge,
                Date_Debut = c.Date_Debut,
                Duree = c.Duree,
                Remaraque = c.Remarques
            }).ToList();
        }
    }
}
