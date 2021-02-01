using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AutoDelovi.WebAPI.Databases
{
    public partial class AutoDeloviiContext : DbContext
    {
        public AutoDeloviiContext()
        {
        }

        public AutoDeloviiContext(DbContextOptions<AutoDeloviiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Marka> Markas { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Narudzba> Narudzbas { get; set; }
        public virtual DbSet<NarudzbaProizvod> NarudzbaProizvods { get; set; }
        public virtual DbSet<Proizvod> Proizvods { get; set; }
        public virtual DbSet<VrstaProizvodum> VrstaProizvoda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Database=AutoDelovii;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Marka>(entity =>
            {
                entity.ToTable("Marka");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("Model");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Marka)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.MarkaId)
                    .HasConstraintName("Model_Marka_FK");
            });

            modelBuilder.Entity<Narudzba>(entity =>
            {
                entity.ToTable("Narudzba");

                entity.Property(e => e.Datum).HasColumnType("date");
            });

            modelBuilder.Entity<NarudzbaProizvod>(entity =>
            {
                entity.HasKey(e => new { e.NarudzbaId, e.ProizvodId })
                    .HasName("NarudzbaProizvod_PK");

                entity.ToTable("NarudzbaProizvod");

                entity.Property(e => e.NarudzbaId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Narudzba)
                    .WithMany(p => p.NarudzbaProizvods)
                    .HasForeignKey(d => d.NarudzbaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("NarudzbaProizvod_Narudzba_FK");

                entity.HasOne(d => d.Proizvod)
                    .WithMany(p => p.NarudzbaProizvods)
                    .HasForeignKey(d => d.ProizvodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("NarudzbaProizvod_Proizvod_FK");
            });

            modelBuilder.Entity<Proizvod>(entity =>
            {
                entity.ToTable("Proizvod");

                entity.Property(e => e.Sifra)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Proizvods)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Model_Proizvod_FK");

                entity.HasOne(d => d.VrstaProizvoda)
                    .WithMany(p => p.Proizvods)
                    .HasForeignKey(d => d.VrstaProizvodaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Vrsta_Proizvod_FK");
            });

            modelBuilder.Entity<VrstaProizvodum>(entity =>
            {
                entity.HasKey(e => e.VrstaProizvodaId)
                    .HasName("VrstaProizvoda_PK");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
