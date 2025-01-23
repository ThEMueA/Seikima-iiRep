using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Seikima_ii.Models;

[Table("Country")]
public partial class Country
{
    [Key]
    [Column("country_code")]
    [StringLength(2)]
    [Unicode(false)]
    public string CountryCode { get; set; } = null!;

    [Column("country_name")]
    [StringLength(25)]
    [Unicode(false)]
    public string? CountryName { get; set; }

    [Column("country_description")]
    [StringLength(100)]
    [Unicode(false)]
    public string? CountryDescription { get; set; }

    [Column("time_zone")]
    [StringLength(9)]
    [Unicode(false)]
    public string? TimeZone { get; set; }

    [InverseProperty("CountryCodeNavigation")]
    public virtual ICollection<Concert> Concerts { get; set; } = new List<Concert>();
}
