//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gestion_Congés
{
    using System;
    using System.Collections.Generic;
    
    public partial class Conge
    {
        public int Matricule { get; set; }
        public Nullable<System.DateTime> DateDebut { get; set; }
        public Nullable<int> Duree { get; set; }
        public Nullable<System.DateTime> DateFin { get; set; }
        public string TypeConge { get; set; }
    
        public virtual GesEmploye GesEmploye { get; set; }
    }
}