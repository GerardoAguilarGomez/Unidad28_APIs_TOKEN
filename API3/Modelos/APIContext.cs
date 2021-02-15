using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API3
{
    public partial class APIContext:DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Cajero> Cajeros { get; set; }
        public virtual DbSet<Maquina> Maquinas { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cajero>(entity =>
            {
                entity.ToTable("Cajeros");
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Codigo).HasColumnName("Codigo");

                entity.Property(e => e.NomApels)
                .HasColumnName("NomsApels")
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Maquina>(entity =>
            {
                entity.ToTable("Maquinas_Registradoras");
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Codigo)
                .HasColumnName("Codigo");

                entity.Property(e => e.Piso)
                .HasColumnName("Piso")
                .IsRequired()
                .IsUnicode(false);
            }
            );

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Productos");
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Codigo)
                .HasColumnName("Codigo");

                entity.Property(e => e.Nombre)
                .HasColumnName("Nombre")
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.Property(e => e.Precio)
                .HasColumnName("Precio")
                .IsRequired()
                .IsUnicode(false);
            }
);

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.ToTable("Ventas");
                entity.HasKey(e => e.Cajero);
                entity.HasKey(j => j.Producto);
                entity.HasKey(k => k.Maquina);

                entity.Property(e => e.Cajero)
                .HasColumnName("Cajero");
                entity.Property(e => e.Maquina)
                .HasColumnName("Maquina");
                entity.Property(e => e.Producto)
                .HasColumnName("Producto");

                entity.HasOne(d => d.Caje)
                .WithMany(e => e.Ventas)
                .HasForeignKey(d => d.Cajero)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Produc)
                .WithMany(e => e.Ventas)
                .HasForeignKey(d => d.Producto)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Maqui)
                .WithMany(e => e.Ventas)
                .HasForeignKey(d => d.Maquina)
                .OnDelete(DeleteBehavior.ClientSetNull);
            }
            )
            ;
            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CC4CE81A3218");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirsName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
