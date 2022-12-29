using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace p4_C00445623_C00441253;

public partial class Author
{
    [Key]
    public long Id { get; set; }

    [Column("Au_ID")]
    public long AuId { get; set; }

    [Column("Author")]
    public string Author1 { get; set; } = null!;

    [Column("Year_Born")]
    public string YearBorn { get; set; } = null!;
}
