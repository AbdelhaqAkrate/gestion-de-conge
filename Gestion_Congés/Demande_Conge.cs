using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Congés
{
    class Demande_Conge
    {
        DemandeEntities demande = new DemandeEntities();
        DemandeConge DC;
        public bool Ajoute_Demande(int Matricule, string Nom, string Prenom, string Type_Conge, DateTime Date_Debut, int Duree, string Remarque)
        {
            DC = new DemandeConge();
            DC.Matricule = Matricule;
            DC.Nom = Nom;
            DC.Prenom = Prenom;
            DC.Type_Conge = Type_Conge;
            DC.Date_Debut = Date_Debut;
            DC.Duree = Duree;
            DC.Remarques = Remarque;
            if (demande.DemandeConges.SingleOrDefault(c => c.Matricule == Matricule) == null)
            {
                demande.DemandeConges.Add(DC);
              
                demande.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
