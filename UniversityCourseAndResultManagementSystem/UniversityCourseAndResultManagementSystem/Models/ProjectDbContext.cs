using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Allocation> Allocations { get; set; }
        public DbSet<AssignCourse> AssignCourses { get; set; }
        public DbSet<Ademo> Ademos { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        //    modelBuilder.Entity<Ademo>()
        //       .HasRequired(f => f.Department)
        //       .WithRequiredDependent()
        //       .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Teacher>()
        //       .HasRequired(f => f.Department)
        //       .WithRequiredDependent()
        //       .WillCascadeOnDelete(false);

        //}

        //public System.Data.Entity.DbSet<UniversityCourseAndResultManagementSystem.Models.Student> Students { get; set; }
    }
}