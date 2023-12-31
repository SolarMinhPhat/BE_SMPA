﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SolarMP.Models
{
    public partial class Feedback
    {
        [Key]
        [Column("feedbackId")]
        [StringLength(16)]
        [Unicode(false)]
        public string FeedbackId { get; set; }
        [Required]
        [Column("description")]
        public string Description { get; set; }
        [Column("createAt", TypeName = "datetime")]
        public DateTime CreateAt { get; set; }
        [Column("status")]
        public bool Status { get; set; }
        [Required]
        [Column("contructionContractId")]
        [StringLength(16)]
        [Unicode(false)]
        public string ContructionContractId { get; set; }
        [Required]
        [Column("accountId")]
        [StringLength(16)]
        [Unicode(false)]
        public string AccountId { get; set; }
        [Column("image")]
        public string Image { get; set; }
        [Required]
        [Column("packageId")]
        [StringLength(16)]
        [Unicode(false)]
        public string PackageId { get; set; }

        [ForeignKey("AccountId")]
        [InverseProperty("Feedback")]
        public virtual Account Account { get; set; }
        [ForeignKey("ContructionContractId")]
        [InverseProperty("Feedback")]
        public virtual ConstructionContract ContructionContract { get; set; }
        [ForeignKey("PackageId")]
        [InverseProperty("Feedback")]
        public virtual Package Package { get; set; }
    }
}