using ExcerciseWebAPI.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Persistence
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Instructor>(
                eb =>
                {
                    eb.ToTable("Instructor").HasKey(i => i.InstructorID);
                    //eb.HasData(new Instructor { InstructorID = 1, LastName="Nguyen", FirstMidName="Ngoc Anh"});
                });
            modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignment").HasKey(o => o.InstructorID);
            modelBuilder.Entity<Department>().ToTable("Department").HasKey(d => d.DepartmentID);
            modelBuilder.Entity<Course>().ToTable("Course").HasKey(c => c.CourseID);
            modelBuilder.Entity<CourseAssignment>(
                eb => {
                    eb.ToTable("CourseAssignment").HasKey(ca => ca.CourseID);
                    eb.HasOne(ca => ca.Instructor).WithMany(i => i.CourseAssignments).HasForeignKey(ca => ca.InstructorID).HasPrincipalKey(i => i.InstructorID);
                    eb.HasOne(ca => ca.Course).WithMany(c => c.CourseAssignments).HasForeignKey(ca => ca.CourseID).HasPrincipalKey(c => c.CourseID);
                });
            modelBuilder.Entity<Student>().ToTable("Student").HasKey(s => s.StudentID);
            modelBuilder.Entity<Enrollment>(
                eb =>
                {
                    eb.ToTable("Enrollment").HasKey(e => e.EnrollmentID);
                    eb.Property(e => e.Grade).HasConversion(e => e.ToString(), e => Enum.Parse<Grades>(e));
                });
        }
    }
}
