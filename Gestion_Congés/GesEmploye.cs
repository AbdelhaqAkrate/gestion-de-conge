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
    
    public partial class GesEmploye
    {
        public int Matricule { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
    
        public virtual Stock_Conge Stock_Conge { get; set; }
        public virtual Conge Conge { get; set; }
    }
}
