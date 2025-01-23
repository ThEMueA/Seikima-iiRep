using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Seikima_ii.Models;

[Table("goodDeals")]
public partial class GoodDeal
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("item_name")]
    [StringLength(40)]
    [Unicode(false)]
    public string? ItemName { get; set; }

    [Column("description_")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Description { get; set; }

    [Column("price", TypeName = "decimal(18, 0)")]
    public decimal? Price { get; set; }

    [Column("item_img_path")]
    [StringLength(256)]
    [Unicode(false)]
    public string? ItemImgPath { get; set; }

    [InverseProperty("Item")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
