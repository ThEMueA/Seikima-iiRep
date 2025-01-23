using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Seikima_ii.Models;

[Table("users")]
public partial class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("fname")]
    [StringLength(25)]
    [Unicode(false)]
    public string? Fname { get; set; }

    [Column("lname")]
    [StringLength(25)]
    [Unicode(false)]
    public string? Lname { get; set; }

    [Column("username")]
    [StringLength(40)]
    [Unicode(false)]
    public string? Username { get; set; }

    [Column("password")]
    [StringLength(40)]
    [Unicode(false)]
    public string? Password { get; set; }

    [Column("user_img")]
    [StringLength(256)]
    [Unicode(false)]
    public string? UserImg { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
