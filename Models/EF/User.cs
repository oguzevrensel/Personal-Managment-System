//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersonelMVC.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        [Display(Name = "Kullan�c� Ad�")]
        public string UserName { get; set; }
        [Display(Name = "�ifre")]
        public string Password { get; set; }
        public int Id { get; set; }
        [Display(Name = "Rol")]
        public string Role { get; set; }
    }
}
