using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcademicSystem.Models
{
    public class Course
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Display(Name = "Plan de Estudios")]
        public int Curriculum { get; set; }
        
        [Display(Name = "Año")]
        public int Year { get; set; }
        
        [Display(Name = "Semestre")]
        public int Semester { get; set; }
        
        [Display(Name = "Código")]
        public string Code { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        public string Name { get; set; } = string.Empty;
        
        [Display(Name = "Sigla")]
        public string? Acronym { get; set; }
        
        [Display(Name = "Créditos")]
        public decimal? Credits { get; set; }
        
        [Display(Name = "Horas Teoría")]
        public decimal? TheoryHours { get; set; }
        
        [Display(Name = "Horas Práctica")]
        public decimal? PracticeHours { get; set; }
        
        [Display(Name = "Horas Laboratorio")]
        public decimal? LaboratoryHours { get; set; }
        
        [Display(Name = "Tiene Laboratorio")]
        public bool Laboratory { get; set; } = true;
        
        [Display(Name = "Estado")]
        public bool Status { get; set; } = true;
        
        [Display(Name = "Fecha Creación")]
        public DateTime Created { get; set; } = DateTime.Now;
        
        [Display(Name = "Fecha Modificación")]
        public DateTime Modified { get; set; } = DateTime.Now;
        
        // Relaciones
        public virtual ICollection<Workload>? Workloads { get; set; }
    }
}