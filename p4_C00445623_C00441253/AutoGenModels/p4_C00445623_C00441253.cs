using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace p4_C00445623_C00441253;

public partial class p4_C00445623_C00441253 : DbContext
{
    public p4_C00445623_C00441253()
    {
    }

    public p4_C00445623_C00441253(DbContextOptions<p4_C00445623_C00441253> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Title> Titles { get; set; }

    public virtual DbSet<TitleAuthor> TitleAuthors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Filename=BooksDB.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
