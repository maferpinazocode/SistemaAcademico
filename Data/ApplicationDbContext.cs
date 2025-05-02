using Microsoft.EntityFrameworkCore;
using AcademicSystem.Models;

namespace AcademicSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Workload> Workloads { get; set; }
        public DbSet<Inscription> Inscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuraciones adicionales
            
            // Restricción única para Workload (Curso + Grupo)
            modelBuilder.Entity<Workload>()
                .HasIndex(w => new { w.CourseId, w.Group })
                .IsUnique();
            
            // Restricción única para Inscription (Estudiante + Workload)
            modelBuilder.Entity<Inscription>()
                .HasIndex(i => new { i.StudentId, i.WorkloadId })
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}