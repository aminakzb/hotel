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
    using System.ComponentModel.DataAnnotations;
    using System.Drawing;
    using System.IO;

    public partial class administrateur
    {
        public int id_admin { get; set; }
        [Required(ErrorMessage = "field required"), MaxLength(10, ErrorMessage = "Last name too long")]
        public string nom_admin { get; set; }
        [Required(ErrorMessage = "field required"), MaxLength(10, ErrorMessage = "First name too long")]
        public string prenom_admin { get; set; }
        [Required(ErrorMessage = "field required"), EmailAddress(ErrorMessage = "Email Address invalid"), MaxLength(30, ErrorMessage = "Email Address too long")]
        public string email_admin { get; set; }
        public byte[] photo_profil { get; set; }
        [Required(ErrorMessage = "field required"), Phone(ErrorMessage ="Phone Number invalid"),MaxLength(10, ErrorMessage = "Phone Number too long")]
        public string tel_admin { get; set; }
        [Required(ErrorMessage = "field required"), MaxLength(10, ErrorMessage = "Login too long")]
        public string login_admin { get; set; }
        [Required(ErrorMessage = "field required"), MinLength(4, ErrorMessage = "Password too short"), MaxLength(10, ErrorMessage = "Password too long")]
        public string mdp_admin { get; set; }

        [Compare("mdp_admin", ErrorMessage = "Passwords don't match")]
        public string mdp_admin2 { get; set; }
        public bool is_superadmin { get; set; }


       
    }
}
