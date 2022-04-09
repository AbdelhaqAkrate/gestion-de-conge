using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Congés
{
    class Gérer_Employes
    {
        private Gestion_CongesEntities Gsc = new Gestion_CongesEntities();
        private GesEmploye GsE;
        private Conge co;
        private Stock_Conge Stc;
        public bool AjouterEmploye(int Matricule, string Nom, string Prenom)
        {
            Stc = new Stock_Conge();
            GsE = new GesEmploye();
            Stc.Matricule=GsE.Matricule = Matricule;
            GsE.Nom = Nom;
            GsE.Prenom = Prenom;
            Stc.NbrJours = 26;
            if (Gsc.GesEmployes.SingleOrDefault(c => c.Matricule == Matricule) == null)
            {
                Gsc.GesEmployes.Add(GsE);
                Gsc.Stock_Conge.Add(Stc);
                Gsc.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ModifierEmploye(int Matricule, string Nom, string Prenom)
        {

            GsE = new GesEmploye();

            GsE = Gsc.GesEmployes.SingleOrDefault(c => c.Matricule == Matricule);
            if (GsE != null)
            {
                GsE.Nom = Nom;
                GsE.Prenom = Prenom;
                Gsc.SaveChanges();
            }
        }
        public void SupprimerEmploye(int Matricule)
        {
            Stc = new Stock_Conge();
            co = new Conge();
            GsE = new GesEmploye();
            Stc = Gsc.Stock_Conge.SingleOrDefault(c => c.Matricule == Matricule);
            co = Gsc.Conges.SingleOrDefault(c => c.Matricule == Matricule);
            GsE = Gsc.GesEmployes.SingleOrDefault(c => c.Matricule == Matricule);
            if (GsE != null && co != null && Stc != null)
            {
                Gsc.Conges.Remove(co);
                Gsc.GesEmployes.Remove(GsE);
                Gsc.Stock_Conge.Remove(Stc);
            }
           if (GsE != null && Stc != null)
            {
                Gsc.GesEmployes.Remove(GsE);
                Gsc.Stock_Conge.Remove(Stc);
            }
            Gsc.SaveChanges();
        }
      

    }
}
