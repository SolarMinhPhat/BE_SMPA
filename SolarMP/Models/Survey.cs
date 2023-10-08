﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SolarMP.Models
{
    public partial class Survey
    {
        [Key]
        [Column("surveyid")]
        [StringLength(16)]
        [Unicode(false)]
        public string Surveyid { get; set; }
        [Column("description")]
        [StringLength(255)]
        [Unicode(false)]
        public string Description { get; set; }
        [Column("note", TypeName = "text")]
        public string Note { get; set; }
        [Column("staffid")]
        [StringLength(16)]
        [Unicode(false)]
        public string Staffid { get; set; }
        [Column("status")]
        public bool Status { get; set; }

        [ForeignKey("Staffid")]
        [InverseProperty("Survey")]
        public virtual Account Staff { get; set; }
    }
}