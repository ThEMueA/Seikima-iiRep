using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Seikima_ii.Models;

[Table("orders")]
public partial class Order
{
    [Key]
    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("user_id_")]
    public int? UserId { get; set; }

    [Column("item_id")]
    public int? ItemId { get; set; }

    [Column("order_date", TypeName = "datetime")]
    public DateTime? OrderDate { get; set; }

    [Column("quantity")]
    public int? Quantity { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("Orders")]
    public virtual GoodDeal? Item { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Orders")]
    public virtual User? User { get; set; }
}
