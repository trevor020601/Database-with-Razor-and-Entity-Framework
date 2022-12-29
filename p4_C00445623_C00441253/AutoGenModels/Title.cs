using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace p4_C00445623_C00441253;

public partial class Title
{
    [Key]
    public long Id { get; set; }

    [Column("Title")]
    public string Title1 { get; set; } = null!;

    [Column("Year_Published")]
    public long YearPublished { get; set; }

    [Column("ISBN")]
    public string Isbn { get; set; } = null!;

    [Column("PubID")]
    public long PubId { get; set; }

    public string Description { get; set; } = null!;

    public string Notes { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Comments { get; set; } = null!;
}
