using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace p4_C00445623_C00441253;

public partial class Publisher
{
    [Key]
    public long Id { get; set; }

    [Column("PubID")]
    public long PubId { get; set; }

    public string Name { get; set; } = null!;

    [Column("Company_Name")]
    public string CompanyName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Zip { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string Fax { get; set; } = null!;

    public string Comments { get; set; } = null!;
}
