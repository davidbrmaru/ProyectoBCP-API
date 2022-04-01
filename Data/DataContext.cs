using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProyectoBCP_API.Models;

#nullable disable

namespace ProyectoBCP_API.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<ApplicationTeamMember> ApplicationTeamMembers { get; set; }
        public virtual DbSet<ChapterAreaLeader> ChapterAreaLeaders { get; set; }
        public virtual DbSet<ChapterLeader> ChapterLeaders { get; set; }
        public virtual DbSet<Squad> Squads { get; set; }
        public virtual DbSet<TeamMember> TeamMembers { get; set; }
        public virtual DbSet<Tribe> Tribes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-BPRK56F;Database=PROYECTOBCP;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Application>(entity =>
            {
                entity.ToTable("APPLICATION");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BindingBlock)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BINDING_BLOCK");

                entity.Property(e => e.CodAplicacion)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("COD_APLICACION");

                entity.Property(e => e.CodOwner)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COD_OWNER");

                entity.Property(e => e.FecActualiza)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_ACTUALIZA");

                entity.Property(e => e.FecIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_INGRESO");

                entity.Property(e => e.FlgActivo).HasColumnName("FLG_ACTIVO");

                entity.Property(e => e.IdSquad).HasColumnName("ID_SQUAD");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.UsuarioActualiza)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO_ACTUALIZA");

                entity.Property(e => e.UsuarioIngresa)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO_INGRESA");

                entity.HasOne(d => d.IdSquadNavigation)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.IdSquad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPLICATION_SQUAD");
            });

            modelBuilder.Entity<ApplicationTeamMember>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("APPLICATION_TEAM_MEMBER");

                entity.Property(e => e.Comentario)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("COMENTARIO");

                entity.Property(e => e.FecIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_INGRESO");

                entity.Property(e => e.IdApplication).HasColumnName("ID_APPLICATION");

                entity.Property(e => e.IdTeamMember).HasColumnName("ID_TEAM_MEMBER");

                entity.Property(e => e.PorAsignado)
                    .HasColumnType("decimal(3, 0)")
                    .HasColumnName("POR_ASIGNADO");

                entity.Property(e => e.UsuarioIngresa)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO_INGRESA");

                entity.HasOne(d => d.IdApplicationNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdApplication)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPLICATION_TEAM_MEMBER_APPLICATION");

                entity.HasOne(d => d.IdTeamMemberNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdTeamMember)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPLICATION_TEAM_MEMBER_TEAM_MEMBER");
            });

            modelBuilder.Entity<ChapterAreaLeader>(entity =>
            {
                entity.ToTable("CHAPTER_AREA_LEADER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDO_MATERNO");

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDO_PATERNO");

                entity.Property(e => e.CodMatricula)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("COD_MATRICULA");

                entity.Property(e => e.FecActualiza)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_ACTUALIZA");

                entity.Property(e => e.FecIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_INGRESO");

                entity.Property(e => e.FlgActivo).HasColumnName("FLG_ACTIVO");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRES");

                entity.Property(e => e.UsuarioActualiza)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO_ACTUALIZA");

                entity.Property(e => e.UsuarioIngresa)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO_INGRESA");
            });

            modelBuilder.Entity<ChapterLeader>(entity =>
            {
                entity.ToTable("CHAPTER_LEADER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDO_MATERNO");

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDO_PATERNO");

                entity.Property(e => e.CodMatricula)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("COD_MATRICULA");

                entity.Property(e => e.FecActualiza)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_ACTUALIZA");

                entity.Property(e => e.FecIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_INGRESO");

                entity.Property(e => e.FlgActivo).HasColumnName("FLG_ACTIVO");

                entity.Property(e => e.IdChapterAreaLeader).HasColumnName("ID_CHAPTER_AREA_LEADER");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRES");

                entity.Property(e => e.UsuarioActualiza)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO_ACTUALIZA");

                entity.Property(e => e.UsuarioIngresa)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO_INGRESA");

                entity.HasOne(d => d.IdChapterAreaLeaderNavigation)
                    .WithMany(p => p.ChapterLeaders)
                    .HasForeignKey(d => d.IdChapterAreaLeader)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHAPTER_LEADER_CHAPTER_AREA_LEADER");
            });

            modelBuilder.Entity<Squad>(entity =>
            {
                entity.ToTable("SQUAD");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FecActualiza)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_ACTUALIZA");

                entity.Property(e => e.FecIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_INGRESO");

                entity.Property(e => e.FlgActivo).HasColumnName("FLG_ACTIVO");

                entity.Property(e => e.IdTribe).HasColumnName("ID_TRIBE");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.UsuarioActualiza)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO_ACTUALIZA");

                entity.Property(e => e.UsuarioIngresa)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO_INGRESA");

                entity.HasOne(d => d.IdTribeNavigation)
                    .WithMany(p => p.Squads)
                    .HasForeignKey(d => d.IdTribe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SQUAD_TRIBE");
            });

            modelBuilder.Entity<TeamMember>(entity =>
            {
                entity.ToTable("TEAM_MEMBER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDO_MATERNO");

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDO_PATERNO");

                entity.Property(e => e.CodMatricula)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("COD_MATRICULA");

                entity.Property(e => e.Empresa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EMPRESA");

                entity.Property(e => e.Especialidad)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ESPECIALIDAD");

                entity.Property(e => e.FecActualiza)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_ACTUALIZA");

                entity.Property(e => e.FecIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_INGRESO");

                entity.Property(e => e.FlgActivo).HasColumnName("FLG_ACTIVO");

                entity.Property(e => e.IdChapterLeader).HasColumnName("ID_CHAPTER_LEADER");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Rol)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROL");

                entity.Property(e => e.RolInsourcing)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROL_INSOURCING");

                entity.Property(e => e.TipoProveedor)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TIPO_PROVEEDOR");

                entity.Property(e => e.UsuarioActualiza)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO_ACTUALIZA");

                entity.Property(e => e.UsuarioIngresa)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO_INGRESA");

                entity.HasOne(d => d.IdChapterLeaderNavigation)
                    .WithMany(p => p.TeamMembers)
                    .HasForeignKey(d => d.IdChapterLeader)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TEAM_MEMBER_CHAPTER_LEADER");
            });

            modelBuilder.Entity<Tribe>(entity =>
            {
                entity.ToTable("TRIBE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FecActualiza)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_ACTUALIZA");

                entity.Property(e => e.FecIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_INGRESO");

                entity.Property(e => e.FlgActivo).HasColumnName("FLG_ACTIVO");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TIPO");

                entity.Property(e => e.UsuarioActualiza)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO_ACTUALIZA");

                entity.Property(e => e.UsuarioIngresa)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO_INGRESA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
