﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities;

public class PackageEntity
{
    [Key]

    public int Id { get; set; }

    public string Title { get; set; } = null!;
    public string SeatingArrangement { get; set; } = null!;

    public string? Placment { get; set; } = null!;

    [Column(TypeName = "decimal(18,2)")]
    public decimal? Price { get; set; }
    public string? Currency {  get; set; }

}
