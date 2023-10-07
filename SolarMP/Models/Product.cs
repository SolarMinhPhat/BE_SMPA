﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SolarMP.Models
{
    public partial class Product
    {
        public Product()
        {
            Image = new HashSet<Image>();
            PackageProduct = new HashSet<PackageProduct>();
            ProductWarrantyReport = new HashSet<ProductWarrantyReport>();
        }

        [Key]
        [Column("productId")]
        [StringLength(10)]
        [Unicode(false)]
        public string ProductId { get; set; }
        [Column("name")]
        [StringLength(255)]
        [Unicode(false)]
        public string Name { get; set; }
        [Column("price", TypeName = "decimal(10, 2)")]
        public decimal? Price { get; set; }
        [Column("manufacturer")]
        [StringLength(100)]
        [Unicode(false)]
        public string Manufacturer { get; set; }
        [Column("feature", TypeName = "text")]
        public string Feature { get; set; }
        [Column("warrantyDate", TypeName = "date")]
        public DateTime? WarrantyDate { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<Image> Image { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<PackageProduct> PackageProduct { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<ProductWarrantyReport> ProductWarrantyReport { get; set; }
    }
}