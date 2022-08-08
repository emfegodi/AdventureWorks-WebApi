using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Data.FluentAPI
{
    [Keyless]
    public partial class Vproducto
    {
        [Column("SalesOrderID")]
        public int SalesOrderId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }
        [Column("suma")]
        [StringLength(51)]
        public string? Suma { get; set; }
        [Column("SalesOrderDetailID")]
        public int SalesOrderDetailId { get; set; }
        [StringLength(25)]
        public string? CarrierTrackingNumber { get; set; }
        [Column(TypeName = "numeric(38, 6)")]
        public decimal LineTotal { get; set; }
        [Column("ProductID")]
        public int ProductId { get; set; }
    }
}
