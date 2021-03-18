using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ItKarieraProjectTest.Models;

namespace ItKarieraProjectTest
{
    public partial class SoftUniProjectDBContext : DbContext
    {
        public SoftUniProjectDBContext()
        {
        }

        public SoftUniProjectDBContext(DbContextOptions<SoftUniProjectDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<PersonInfo> PersonInfo { get; set; }
        public virtual DbSet<WorkersProfile> WorkersProfile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=127.0.0.1;Database=softuniprojectdb; uID=root; pwd=Viktoria7589610; persistsecurityinfo=True");
                //promeni
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Companies>(entity =>
            {
                entity.ToTable("companies");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);

                entity.Property(e => e.Rate).HasColumnName("rate");
            });

            modelBuilder.Entity<PersonInfo>(entity =>
            {
                entity.ToTable("person_info");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("company_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(60);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(60);

                entity.Property(e => e.Money)
                    .HasColumnName("money")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.WorkHours).HasColumnName("work_hours");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.PersonInfo)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("person_info_ibfk_1");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.PersonInfo)
                    .HasForeignKey<PersonInfo>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("person_info_ibfk_2");
            });

            modelBuilder.Entity<WorkersProfile>(entity =>
            {
                entity.ToTable("workers_profile");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(45);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
