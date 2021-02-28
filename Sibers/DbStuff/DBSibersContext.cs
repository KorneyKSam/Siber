using Microsoft.EntityFrameworkCore;
using Sibers.DbStuff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibers.DbStuff
{
    public partial class DBSibersContext : DbContext
    {
        public DbSet<CustomerCompany> CustomerCompanies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeProject> EployeeProjects { get; set; }
        public DbSet<ExecutingCompany> ExecutingCompanies { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }

        public DBSibersContext(DbContextOptions dbContext) : base(dbContext) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<CustomerCompany>(entity =>
            {
                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.DateTimeOfCreation).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);
            });

            modelBuilder.Entity<EmployeeProject>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.ProjectId })
                    .HasName("PK_ProjectExecutors");

                entity.ToTable("EmployeeProject");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.DateTimeOfCreation).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeesProjects)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectExecutors_Employees");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.EployeeProjects)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectExecutors_Projects");
            });

            modelBuilder.Entity<ExecutingCompany>(entity =>
            {
                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.CustomerCompanyId).HasColumnName("CustomerCompanyID");

                entity.Property(e => e.DateTimeOfCreation).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.ExecutingCompanyId).HasColumnName("ExecutingCompanyID");

                entity.Property(e => e.ProjectLeaderId).HasColumnName("ProjectLeaderID");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.CustomerCompany)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.CustomerCompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_CustomerCompanies");

                entity.HasOne(d => d.ExecutingCompany)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ExecutingCompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_ExecutingCompanies");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            //OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
