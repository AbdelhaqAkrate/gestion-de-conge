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
    public partial class User_Expire : UserControl
    {
        private GesEmploye GsE=new GesEmploye();
        private Conge co=new Conge();
        private Stock_Conge Stc = new Stock_Conge();
        Gestion_CongesEntities Gsc = new Gestion_CongesEntities();
        public User_Expire()
        {
            InitializeComponent();
        }
        public static User_Expire UE;
        public static User_Expire User
        {
            get
            {
                if (UE == null)
                {
                    UE = new User_Expire();
                }
                return UE;
            }
        }
        private void User_Expire_Load(object sender, EventArgs e)
        {
            DateTime startyear = DateTime.Now;

            DateTime now = DateTime.Now;
            DateTime nextwoyear = now.AddYears(2);
            int NextwoYearMonth = nextwoyear.Month;
            int nowMonth = now.Month;

            if (nowMonth == 11 && NextwoYearMonth == 11 && now == nextwoyear)
            {
                if (Stc.NbrJours > 26)
                {
                //    button9.BackgroundImage = System.Drawing.Image.FromFile(@"C:\Users\KANNA G\Desktop\Gestion De Congés\Gestion_Congés\Gestion_Congés\Image\213-alarm.png");
                    dataGridView1.DataSource = Gsc.Conges.Select(c => new
                    {
                        Matricule = c.GesEmploye.Matricule,
                        Nom = c.GesEmploye.Nom,
                        Prenom = c.GesEmploye.Prenom,
                        Type_Congé = c.TypeConge,
                        Durée = c.Duree,
                        Date_Debut = c.DateDebut,
                        Date_Final = c.DateFin
                    }).ToList();
                }
            
            }
        }
    }
}
