﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SolarMP.Models
{
    public partial class ConstructionContract
    {
        public ConstructionContract()
        {
            Acceptance = new HashSet<Acceptance>();
            PaymentProcess = new HashSet<PaymentProcess>();
            Process = new HashSet<Process>();
            WarrantyReport = new HashSet<WarrantyReport>();
        }

        [Key]
        [Column("constructioncontractID")]
        [StringLength(16)]
        [Unicode(false)]
        public string ConstructioncontractId { get; set; }
        [Column("status")]
        public bool? Status { get; set; }
        [Column("startdate", TypeName = "date")]
        public DateTime? Startdate { get; set; }
        [Column("enddate", TypeName = "date")]
        public DateTime? Enddate { get; set; }
        [Column("totalcost", TypeName = "decimal(10, 2)")]
        public decimal? Totalcost { get; set; }
        [Column("isConfirmed")]
        public bool? IsConfirmed { get; set; }
        [Column("imageFile")]
        public byte[] ImageFile { get; set; }
        [Column("customerid")]
        [StringLength(16)]
        [Unicode(false)]
        public string Customerid { get; set; }
        [Column("staffid")]
        [StringLength(16)]
        [Unicode(false)]
        public string Staffid { get; set; }
        [Column("packageid")]
        [StringLength(16)]
        [Unicode(false)]
        public string Packageid { get; set; }
        [Column("bracketid")]
        [StringLength(16)]
        [Unicode(false)]
        public string Bracketid { get; set; }

        [ForeignKey("Bracketid")]
        [InverseProperty("ConstructionContract")]
        public virtual Bracket Bracket { get; set; }
        [ForeignKey("Packageid")]
        [InverseProperty("ConstructionContract")]
        public virtual Package Package { get; set; }
        [InverseProperty("Constructioncontract")]
        public virtual ICollection<Acceptance> Acceptance { get; set; }
        [InverseProperty("Constructioncontract")]
        public virtual ICollection<PaymentProcess> PaymentProcess { get; set; }
        [InverseProperty("Contract")]
        public virtual ICollection<Process> Process { get; set; }
        [InverseProperty("Contract")]
        public virtual ICollection<WarrantyReport> WarrantyReport { get; set; }
    }
}