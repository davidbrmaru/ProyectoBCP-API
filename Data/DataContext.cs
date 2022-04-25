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
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<RolSubMenu> RolSubMenus { get; set; }
        public virtual DbSet<Squad> Squads { get; set; }
        public virtual DbSet<SubMenu> SubMenus { get; set; }
        public virtual DbSet<TeamMember> TeamMembers { get; set; }
        public virtual DbSet<Tribe> Tribes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=KATAKURI;Database=PROYECTOBCP;Trusted_Connection=True");
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
                entity.ToTable("APPLICATION_TEAM_MEMBER");

                entity.Property(e => e.Id).HasColumnName("ID");

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
                    .WithMany(p => p.ApplicationTeamMembers)
                    .HasForeignKey(d => d.IdApplication)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPLICATION_TEAM_MEMBER_APPLICATION");

                entity.HasOne(d => d.IdTeamMemberNavigation)
                    .WithMany(p => p.ApplicationTeamMembers)
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

                entity.Property(e => e.NombreChapter)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_CHAPTER");

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

                entity.Property(e => e.NombreChapter)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_CHAPTER");

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

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LOG");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Exception)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Logger)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Thread)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("MENU");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CodMenu)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("COD_MENU");

                entity.Property(e => e.FecActualiza)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_ACTUALIZA");

                entity.Property(e => e.FecIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_INGRESO");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Tittle).HasColumnName("TITTLE");

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

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("ROL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CodRol)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("COD_ROL");

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

            modelBuilder.Entity<RolSubMenu>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ROL_SUB_MENU");

                entity.Property(e => e.FecIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_INGRESO");

                entity.Property(e => e.FlgActivo).HasColumnName("FLG_ACTIVO");

                entity.Property(e => e.IdRol).HasColumnName("ID_ROL");

                entity.Property(e => e.IdSubMenu).HasColumnName("ID_SUB_MENU");

                entity.Property(e => e.UsuarioIngresa)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO_INGRESA");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ROL_SUB_MENU_ROL");

                entity.HasOne(d => d.IdSubMenuNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSubMenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ROL_SUB_MENU_SUB_MENU");
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

            modelBuilder.Entity<SubMenu>(entity =>
            {
                entity.ToTable("SUB_MENU");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FecActualiza)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_ACTUALIZA");

                entity.Property(e => e.FecIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_INGRESO");

                entity.Property(e => e.FlgActivo).HasColumnName("FLG_ACTIVO");

                entity.Property(e => e.Icon)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ICON");

                entity.Property(e => e.IdMenu).HasColumnName("ID_MENU");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("URL");

                entity.Property(e => e.UsuarioActualiza)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO_ACTUALIZA");

                entity.Property(e => e.UsuarioIngresa)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO_INGRESA");

                entity.HasOne(d => d.IdMenuNavigation)
                    .WithMany(p => p.SubMenus)
                    .HasForeignKey(d => d.IdMenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SUB_MENU");
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

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CodMatricula)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("COD_MATRICULA");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

                entity.Property(e => e.FecActualiza)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_ACTUALIZA");

                entity.Property(e => e.FecIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_INGRESO");

                entity.Property(e => e.FlgActivo).HasColumnName("FLG_ACTIVO");

                entity.Property(e => e.IdRol).HasColumnName("ID_ROL");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.UsuarioActualiza)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO_ACTUALIZA");

                entity.Property(e => e.UsuarioIngresa)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO_INGRESA");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_ROL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
