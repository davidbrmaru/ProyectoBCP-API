using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using trabajo_final_API.Models;

#nullable disable

namespace trabajo_final_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbSquad> TbSquads { get; set; }
        public virtual DbSet<TbTribu> TbTribus { get; set; }
        public virtual DbSet<TbAplicacion> TbAplicacion { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-BPRK56F;Database=bd_trabajo_final;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<TbSquad>(entity =>
            {
                entity.ToTable("tb_squad");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("id");

                entity.Property(e => e.IdTribu)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("id_tribu");

                entity.Property(e => e.SquadName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("squad_name");

                entity.HasOne(d => d.IdTribuNavigation)
                    .WithMany(p => p.TbSquads)
                    .HasForeignKey(d => d.IdTribu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_squad_tb_squad");
            });

            modelBuilder.Entity<TbTribu>(entity =>
            {
                entity.ToTable("tb_tribu");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("id");

                entity.Property(e => e.TribuName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tribu_name");
            });


            modelBuilder.Entity<TbAplicacion>(entity =>
            {
                entity.ToTable("tb_tribu");

                entity.Property(e => e.Id_Aplicacion)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("id");

                entity.Property(e => e.Id_SquadApp)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tribu_name");
            });

        }

    }
}
