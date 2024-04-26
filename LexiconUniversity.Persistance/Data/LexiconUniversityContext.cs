using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LexiconUniversity.Core.Entities;

namespace LexiconUniversity.Persistance.Data
{
    public class LexiconUniversityContext : DbContext
    {
        public LexiconUniversityContext(DbContextOptions<LexiconUniversityContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; } = default!;
        public DbSet<Course> Courses { get; set; } = default!;

        public DbSet<Enrollment> Enrollments { get; set; } = default!; 

        //Not needed for convention 2
        //public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Wrong name
            //modelBuilder.Entity<Student>().OwnsOne(s => s.Name); 

            modelBuilder.Entity<Student>()
                .OwnsOne(s => s.Name)
                .Property(n => n.FirstName)
                .HasColumnName("FirstName");

            modelBuilder.Entity<Student>()
                .OwnsOne(s => s.Name)
                .Property(n => n.LastName)
                .HasColumnName("LastName");

            //modelBuilder.Entity<Student>().HasOne(s => s.Address)
            //    .WithOne(a => a.Student)
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                .UsingEntity<Enrollment>(
                e=> e.HasOne(e=>e.Course).WithMany(c=>c.Enrollments),
                e =>e.HasOne(e=>e.Student).WithMany(s=>s.Enrollments),
                e =>e.HasKey(e =>new {e.CourseId, e.StudentId}));

            //modelBuilder.Entity<Enrollment>().HasKey(e => new { e.StudentId, e.CourseId }); 
        }
    }
}
