using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API4
{
    public partial class APIContext:DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
       : base(options)
        {
        }

        public virtual DbSet<Equipo> Equipos { get; set; }
        public virtual DbSet<Facultad> Facultades { get; set; }
        public virtual DbSet<Investigador> Investigadores { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }

        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.ToTable("Equipos");
                entity.HasKey(e => e.NumSerie);
                entity.Property(e => e.NumSerie).HasColumnName("numSerie");

                entity.Property(e => e.Nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.Property(e => e.Facultad)
                .HasColumnName("facultad");

                entity.HasOne(d => d.Facul)
               .WithMany(e => e.Equipos)
               .HasForeignKey(d => d.Facultad)
               .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Facultad>(entity =>
            {
                entity.ToTable("Facultad");
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Codigo)
                .HasColumnName("codigo");

                entity.Property(e => e.Nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .IsUnicode(false);
            }
            );

            modelBuilder.Entity<Investigador>(entity =>
            {
                entity.ToTable("Investigadores");
                entity.HasKey(e => e.Dni);
                entity.Property(e => e.Dni).HasColumnName("DNI");

                entity.Property(e => e.NomApels)
                .HasColumnName("nomApels")
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

                entity.Property(e => e.Facultad)
                .HasColumnName("facultad");

                entity.HasOne(d => d.Facul)
               .WithMany(e => e.Investigadores)
               .HasForeignKey(d => d.Facultad)
               .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.ToTable("Reserva");
                entity.HasKey(e => e.Equipo);
                entity.HasKey(j => j.Investigador);

                entity.Property(e => e.Equipo)
                .HasColumnName("numSerie");
                entity.Property(e => e.Investigador)
                .HasColumnName("DNI");

                entity.HasOne(d => d.Equip)
                .WithMany(e => e.Reservas)
                .HasForeignKey(d => d.Equipo)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Inves)
                .WithMany(e => e.Reservas)
                .HasForeignKey(d => d.Investigador)
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
