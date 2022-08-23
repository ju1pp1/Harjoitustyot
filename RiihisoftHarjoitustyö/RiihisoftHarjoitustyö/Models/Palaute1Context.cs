using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RiihisoftHarjoitustyö.Models
{
    public partial class Palaute1Context : DbContext
    {
        public Palaute1Context()
        {
        }

        public Palaute1Context(DbContextOptions<Palaute1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Palaute1> Palaute1s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-FKIMM58\\SQLEXPRESS;Database=Palaute1;Trusted_Connection=True;");
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-FKIMM58\\SQLEXPRESS;Database=Palaute1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Palaute1>(entity =>
            {
                entity.ToTable("Palaute_1");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AvoinPalaute)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("AvoinPalaute");

                entity.Property(e => e.Etunimi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sukunimi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sähköposti)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
