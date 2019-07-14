namespace ChemAnalyst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class SA_UserViewModel
    {
        [Key]
        public int id { get; set; }
        [StringLength(50)]
        public string Fname { get; set; }

        [StringLength(50)]
        public string Lname { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(500)]
        public string UserPassword { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        [StringLength(50)]
        public string ProfileImage { get; set; }

        public string Role { get; set; }
        public Gender StudentGender { get; set; }
        public List<SelectListItem> UserRoleList { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
    public enum UserRole
    {
        Admin,
        Sale,
        Customer
    }
}
