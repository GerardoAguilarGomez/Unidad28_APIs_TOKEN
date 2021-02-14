using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using API1.Controllers;

namespace API1
{
    public class APIContext:DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
      : base(options)
        {
        }

        public virtual DbSet<Pieza> Piezas { get; set; }
        public virtual DbSet<Proveedor> Proveedores { get; set; }
        public virtual DbSet<Suministra> Suministras { get; set; }

        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pieza>(entity =>
            {

                entity.ToTable("Piezas");
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Codigo).HasColumnName("Codigo");

                entity.Property(e => e.Nombre)
                .HasColumnName("Nombre")
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.ToTable("Proveedores");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                .HasColumnName("Id")
                .HasMaxLength(4);
                
                entity.Property(e => e.Nombre)
                .HasColumnName("Nombre")
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            }
            );

            modelBuilder.Entity<Suministra>(entity =>
            {
                entity.ToTable("Suministra");
                entity.HasKey(e => e.Codigo_pieza);
                entity.HasKey(j => j.Id_proveedor);
                entity.Property(e => e.Codigo_pieza)
                .HasColumnName("CodigoPieza");
                entity.Property(e => e.Id_proveedor)
                .HasColumnName("IdProveedor");

                entity.HasOne(d => d.Pie)
                .WithMany(e => e.Suministras)
                .HasForeignKey(d => d.Codigo_pieza)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Provee)
                .WithMany(e => e.Suministras)
                .HasForeignKey(d => d.Id_proveedor)
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

           //OnModelCreatingPartial(modelBuilder);
        
        }


        public DbSet<API1.Suministra> Suministra { get; set; }
    }
}
