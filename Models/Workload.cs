using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademicSystem.Models
{
    public class Workload
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [ForeignKey("Course")]
        [Display(Name = "Curso")]
        public Guid CourseId { get; set; }
        
        [Display(Name = "Curso")]
        public virtual Course? Course { get; set; }
        
        [Required]
        [ForeignKey("Teacher")]
        [Display(Name = "Profesor")]
        public int TeacherId { get; set; }
        
        [Display(Name = "Profesor")]
        public virtual Teacher? Teacher { get; set; }
        
        [Required]
        [Display(Name = "Grupo")]
        public string Group { get; set; } = "A";
        
        [Required]
        [Display(Name = "Laboratorio")]
        public string Laboratory { get; set; } = "lab01";
        
        [Required]
        [Display(Name = "Capacidad")]
        public int Capacity { get; set; } = 20;
        
        [Display(Name = "Estado")]
        public bool Status { get; set; } = true;
        
        [Display(Name = "Fecha Creación")]
        public DateTime Created { get; set; } = DateTime.Now;
        
        [Display(Name = "Fecha Modificación")]
        public DateTime Modified { get; set; } = DateTime.Now;
        
        // Relaciones
        public virtual ICollection<Inscription>? Inscriptions { get; set; }
    }
}