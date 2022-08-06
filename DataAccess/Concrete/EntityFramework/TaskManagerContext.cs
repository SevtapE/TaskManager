using Core.Core.Security.Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Task = Entities.Concrete.Task;

namespace DataAccess.Concrete.EntityFramework
{
    public class TaskManagerContext:DbContext
    {

        protected IConfiguration Configuration { get; set; }
        public TaskManagerContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=TaskManagerProjectDB;Trusted_Connection=true");
        }


        public DbSet<Admin> Admins { get; set; }
        public DbSet<Clarification> Clarifications { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<TaskWorker> Assignments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<UserOperationClaim>(b =>
            {
                b.ToTable("UserOperationClaims").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.UserId).HasColumnName("UserId");
                b.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");


            });
            modelBuilder.Entity<User>(b =>
            {
                b.ToTable("Users").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.FirstName).HasColumnName("FirstName");
                b.Property(p => p.LastName).HasColumnName("LastName");
                b.Property(p => p.Email).HasColumnName("Email");
                b.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                b.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                b.Property(p => p.Status).HasColumnName("Status");

            });
            modelBuilder.Entity<OperationClaim>(b =>
            {
                b.ToTable("OperationClaims").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name");


            });

            modelBuilder.Entity<Admin>(b =>
            {
                b.ToTable("Admins");
                b.Property(a => a.AdminDescription).HasColumnName("AdminDescription");

            });

            modelBuilder.Entity<Clarification>(b =>
            {
                b.ToTable("Clarifications").HasKey(c => c.Id);
                b.Property(c => c.Title).HasColumnName("Title");
                b.Property(c => c.Content).HasColumnName("Content");
                b.Property(c => c.CreationDate).HasColumnName("CreationDate");
                b.Property(c => c.TaskId).HasColumnName("TaskId");
                b.Property(c => c.PersonId).HasColumnName("PersonId");
                b.HasOne(c => c.Task);
                b.HasOne(c => c.Person);


            });
            modelBuilder.Entity<TaskWorker>(b =>
            {
                b.ToTable("TaskWorkers").HasKey(c => c.Id);
                b.Property(c => c.TaskId).HasColumnName("TaskId");
                b.Property(c => c.WorkerId).HasColumnName("WorkerId");
             


            });
            modelBuilder.Entity<Company>(b =>
            {
                b.ToTable("Companies").HasKey(c => c.CompanyId);
                b.Property(p => p.CompanyName).HasColumnName("CompanyName");
                b.HasMany(c => c.Employees);



            });
            modelBuilder.Entity<Document>(b =>
            {
                b.ToTable("Documents").HasKey(c => c.Id);
                b.Property(p => p.Name).HasColumnName("Name");
                b.Property(p => p.Link).HasColumnName("Link");
                b.Property(p => p.TaskId).HasColumnName("TaskId");
                b.HasOne(p => p.Task);




            });
            modelBuilder.Entity<Employee>(b =>
            {
                b.ToTable("Employees");

                b.Property(p => p.EmployeeRegistrationNumber).HasColumnName("EmployeeRegistrationNumber");
                b.Property(p => p.CompanyId).HasColumnName("CompanyId");
                b.HasOne(p => p.Company);

            });

            modelBuilder.Entity<Manager>(b =>
            {
                b.ToTable("Managers");
                b.Property(p => p.Title).HasColumnName("Title");
                b.HasMany(p => p.Workers);

            });
            modelBuilder.Entity<Person>(b =>
            {
                b.ToTable("Persons").HasKey(k => k.Id);
                b.Property(p => p.UserId).HasColumnName("UserId");
                b.HasOne(c => c.User);

            });

            modelBuilder.Entity<Task>(b =>
            {
                b.ToTable("Tasks").HasKey(k => k.Id);
                b.Property(p => p.Title).HasColumnName("Title");
                b.Property(p => p.Content).HasColumnName("Content");
                b.Property(p => p.StartDate).HasColumnName("StartDate");
                b.Property(p => p.EndDate).HasColumnName("EndDate");
                b.Property(p => p.Deadline).HasColumnName("Deadline");
                b.Property(p => p.CreationDate).HasColumnName("CreationDate");
                b.Property(p => p.Urgent).HasColumnName("Urgent");
                b.Property(p => p.Important).HasColumnName("Important");
                b.Property(p => p.TaskState).HasColumnName("TaskState");
                b.Property(p => p.CompanyId).HasColumnName("CompanyId");
                b.Property(p => p.PersonId).HasColumnName("PersonId");
                b.HasOne(p => p.Company);
                b.HasOne(p => p.Person);
                b.HasMany(p => p.Clarifications);
                b.HasMany(p => p.Documents);


            });

            modelBuilder.Entity<Worker>(m =>
            {
                m.ToTable("Workers");
                m.Property(p => p.ManagerId).HasColumnName("ManagerId");
                m.HasOne(p => p.Manager);


            });
        }

    }
}
