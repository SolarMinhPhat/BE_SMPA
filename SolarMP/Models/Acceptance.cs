﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SolarMP.Models
{
    public partial class Acceptance
    {
        [Key]
        [Column("acceptanceid")]
        [StringLength(16)]
        [Unicode(false)]
        public string Acceptanceid { get; set; }
        [Column("status")]
        public bool? Status { get; set; }
        [Column("rating")]
        public int? Rating { get; set; }
        [Column("feedback", TypeName = "text")]
        public string Feedback { get; set; }
        [Column("constructioncontractid")]
        [StringLength(16)]
        [Unicode(false)]
        public string Constructioncontractid { get; set; }
        [Column("imageFile")]
        public byte[] ImageFile { get; set; }

        [ForeignKey("Constructioncontractid")]
        [InverseProperty("Acceptance")]
        public virtual ConstructionContract Constructioncontract { get; set; }
    }
}