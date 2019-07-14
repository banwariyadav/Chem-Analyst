﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemAnalyst.Models
{
    public class SA_Customer
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

        [StringLength(50)]
        public string Role { get; set; }

        [StringLength(50)]
        public string MenuId { get; set; }
    }
}