using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Seikima_ii.Models;

[Table("concerts")]
public partial class Concert
{
    [Key]
    [Column("concert_id")]
    public int ConcertId { get; set; }

    [Column("country_code")]
    [StringLength(2)]
    [Unicode(false)]
    public string? CountryCode { get; set; }

    [Column("name_")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("date_", TypeName = "datetime")]
    public DateTime? Date { get; set; }

    [Column("program")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Program { get; set; }

    [Column("img_path")]
    [StringLength(256)]
    [Unicode(false)]
    public string? ImgPath { get; set; }

    [ForeignKey("CountryCode")]
    [InverseProperty("Concerts")]
    public virtual Country? CountryCodeNavigation { get; set; }
}
