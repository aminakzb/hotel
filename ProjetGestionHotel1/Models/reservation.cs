//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetGestionHotel1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class reservation
    {
        public int id_reservation { get; set; }
        public int id_chambre { get; set; }
        public int id_client { get; set; }
        public System.DateTime debut_reservation { get; set; }
        public System.DateTime fin_reservation { get; set; }
        public string statut { get; set; }
        public int nbr_personne { get; set; }
    
        public virtual chambre chambre { get; set; }
        public virtual client client { get; set; }
    }
}
