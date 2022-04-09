using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Gestion_Congés
{
    class Gérer_Conges
    {
        private Gestion_CongesEntities Gsc = new Gestion_CongesEntities();
        private Conge C;
        private GesEmploye GsE;
        private Stock_Conge Stc;
        public bool AjouterConge(int Matricule,string Type_Conge, DateTime Date_Debut, int Duree)
        {
         
            C = new Conge();
            GsE = new GesEmploye();
            int DateFinUpdate;
            int CountSundays = 0;
            int CountHoludays = 0;
            for (int j = 0; j <= Duree; j++)
            {
                if (Date_Debut.AddDays(j).ToString("dddd") == "Sunday")
                {
                    CountSundays++;
                }
            }
            for (int j = 0; j <= Duree; j++)
            {
                if (Date_Debut.AddDays(j).Day == 1 && Date_Debut.AddDays(j).Day == 1)
                {
                    CountHoludays++;
                }
                if (Date_Debut.AddDays(j).Day == 11 && Date_Debut.AddDays(j).Day == 1)
                {
                    CountHoludays++;
                }
                if (Date_Debut.AddDays(j).Day == 1 && Date_Debut.AddDays(j).Day == 5)
                {
                    CountHoludays++;
                }
                if (Date_Debut.AddDays(j).Day == 30 && Date_Debut.AddDays(j).Day == 7)
                {
                    CountHoludays++;
                }
                if (Date_Debut.AddDays(j).Day == 14 && Date_Debut.AddDays(j).Day == 8)
                {
                    CountHoludays++;
                }
                if (Date_Debut.AddDays(j).Day == 20 && Date_Debut.AddDays(j).Day == 8)
                {
                    CountHoludays++;
                }
                if (Date_Debut.AddDays(j).Day == 21 && Date_Debut.AddDays(j).Day == 8)
                {
                    CountHoludays++;
                }
                if (Date_Debut.AddDays(j).Day == 6 && Date_Debut.AddDays(j).Day == 11)
                {
                    CountHoludays++;
                }
                if (Date_Debut.AddDays(j).Day == 18 && Date_Debut.AddDays(j).Day == 11)
                {
                    CountHoludays++;
                }
            }
           
            DateFinUpdate = Duree + CountSundays + CountHoludays;
            C.DateFin = Date_Debut.AddDays(DateFinUpdate);
            C.Matricule = GsE.Matricule = Matricule;
            C.TypeConge = Type_Conge;
            C.DateDebut = Date_Debut;
            C.Duree = Duree;
            if (Gsc.Conges.SingleOrDefault(c => c.Matricule == Matricule && c.Matricule == c.GesEmploye.Matricule) == null)
            {
                Gsc.Conges.Add(C);
                Gsc.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Modifier_Stock_Conge(int Matricule,int Duree)
        {

            Stc = new Stock_Conge();
            Stc = Gsc.Stock_Conge.SingleOrDefault(c => c.Matricule == Matricule);
            if (Stc != null)
            {
                Stc.NbrJours-=Duree;
                Gsc.SaveChanges();
            }
        }
        public void Nbjours()
        {
            Stc = new Stock_Conge();
            DateTime startyear = DateTime.Now;
            
            DateTime nextyear = startyear.AddYears(1);
            DateTime nexttwoyear = startyear.AddYears(2);
            int res = DateTime.Compare(startyear, nextyear);
            if (res < 0)
            {
                Stc.NbrJours = Stc.NbrJours;
            }
            else if (res == 0)
            {
                Stc.NbrJours += 26;
            }
            else
            {
                res = DateTime.Compare(startyear, nexttwoyear);
                if (res < 0)
                {
                    Stc.NbrJours = Stc.NbrJours;
                }
                else if (res == 0)
                {
                    Stc.NbrJours -= 26;
                }
                else
                {
                    startyear = DateTime.Now;
                }
            }
            Gsc.SaveChanges();
        }
        public void SupprimerConge(int Matricule)
        {
            C = new Conge();
            C = Gsc.Conges.SingleOrDefault(c => c.Matricule == Matricule);
              if (C != null)
            {
               Gsc.Conges.Remove(C);
            }
            Gsc.SaveChanges();
        }
    }
}

