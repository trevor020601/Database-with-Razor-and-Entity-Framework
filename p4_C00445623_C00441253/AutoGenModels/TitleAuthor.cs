using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace p4_C00445623_C00441253;

public partial class TitleAuthor
{
    [Key]
    public long Id { get; set; }

    [Column("ISBN")]
    public string Isbn { get; set; } = null!;

    [Column("Au_ID")]
    public long AuId { get; set; }
}
