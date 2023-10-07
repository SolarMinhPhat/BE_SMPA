﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SolarMP.Models
{
    public partial class Promotion
    {
        public Promotion()
        {
            Package = new HashSet<Package>();
        }

        [Key]
        [Column("promotionid")]
        [StringLength(10)]
        [Unicode(false)]
        public string Promotionid { get; set; }
        [Column("amount", TypeName = "decimal(18, 0)")]
        public decimal? Amount { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("startdate", TypeName = "datetime")]
        public DateTime? Startdate { get; set; }
        [Column("enddate", TypeName = "datetime")]
        public DateTime? Enddate { get; set; }
        [Column("createAt", TypeName = "datetime")]
        public DateTime? CreateAt { get; set; }

        [InverseProperty("Promotion")]
        public virtual ICollection<Package> Package { get; set; }
    }
}