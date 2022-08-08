﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Data.FluentAPI
{
    /// <summary>
    /// Street address information for customers, employees, and vendors.
    /// </summary>
    [Table("Address", Schema = "Person")]
    [Index("PostalCode", Name = "IX_Address")]
    public partial class Address
    {
        public Address()
        {
            BusinessEntityAddresses = new HashSet<BusinessEntityAddress>();
            SalesOrderHeaderBillToAddresses = new HashSet<SalesOrderHeader>();
            SalesOrderHeaderShipToAddresses = new HashSet<SalesOrderHeader>();
        }

        /// <summary>
        /// Primary key for Address records.
        /// </summary>
        [Key]
        [Column("AddressID")]
        public int AddressId { get; set; }
        /// <summary>
        /// First street address line.
        /// </summary>
        [StringLength(60)]
        public string AddressLine1 { get; set; } = null!;
        /// <summary>
        /// Second street address line.
        /// </summary>
        [StringLength(60)]
        public string? AddressLine2 { get; set; }
        /// <summary>
        /// Name of the city.
        /// </summary>
        [StringLength(30)]
        public string City { get; set; } = null!;
        /// <summary>
        /// Unique identification number for the state or province. Foreign key to StateProvince table.
        /// </summary>
        [Column("StateProvinceID")]
        public int StateProvinceId { get; set; }
        /// <summary>
        /// Postal code for the street address.
        /// </summary>
        [StringLength(15)]
        public string PostalCode { get; set; } = null!;
        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// </summary>
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("StateProvinceId")]
        [InverseProperty("Addresses")]
        public virtual StateProvince StateProvince { get; set; } = null!;
        [InverseProperty("Address")]
        public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
        [InverseProperty("BillToAddress")]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaderBillToAddresses { get; set; }
        [InverseProperty("ShipToAddress")]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaderShipToAddresses { get; set; }
    }
}
