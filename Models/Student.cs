using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcademicSystem.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "CUI")]
        public int? Cui { get; set; }
        
        [Required(ErrorMessage = "Los nombres son obligatorios")]
        [Display(Name = "Nombres")]
        public string Names { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "El apellido paterno es obligatorio")]
        [Display(Name = "Apellido Paterno")]
        public string FatherSurname { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "El apellido materno es obligatorio")]
        [Display(Name = "Apellido Materno")]
        public string MotherSurname { get; set; } = string.Empty;
        
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string? Email { get; set; }
        
        [Display(Name = "Teléfono")]
        public string? Phone { get; set; }
        
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