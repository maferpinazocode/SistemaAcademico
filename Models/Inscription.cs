using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademicSystem.Models
{
    public class Inscription
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [ForeignKey("Student")]
        [Display(Name = "Estudiante")]
        public int StudentId { get; set; }
        
        [Display(Name = "Estudiante")]
        public virtual Student? Student { get; set; }
        
        [Required]
        [ForeignKey("Workload")]
        [Display(Name = "Campo de Trabajo")]
        public int WorkloadId { get; set; }
        
        [Display(Name = "Campo de Trabajo")]
        public virtual Workload? Workload { get; set; }
        
        [Display(Name = "Estado")]
        public bool Status { get; set; } = true;
        
        [Display(Name = "Fecha Creación")]
        public DateTime Created { get; set; } = DateTime.Now;
        
        [Display(Name = "Fecha Modificación")]
        public DateTime Modified { get; set; } = DateTime.Now;
    }
}