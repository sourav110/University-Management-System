using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Please enter course Code")]
        [MinLength(5, ErrorMessage = "Code must be at least 5 character long")]
        [Display(Name = "Code")]
        [Column(TypeName = "varchar")]
        [Remote("IsCodeExists", "Courses", ErrorMessage = "Course Code already exists")]
        public string CourseCode { get; set; }

        [Required(ErrorMessage = "Please enter course Name")]
        [Display(Name = "Name")]
        [Column(TypeName = "varchar")]
        [Remote("IsNameExists", "Courses", ErrorMessage = "Course Name already exists")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Please enter Credit")]
        [Range(0.5, 5.0, ErrorMessage ="Credit must be in range between 0.5 to 5.0")]
        public float CourseCredit { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [Display(Name = "Semester")]
        public int SemesterId { get; set; }
        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }
    }
}