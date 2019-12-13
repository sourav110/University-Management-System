using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class Ademo
    {
        [Key]
        public int AdemoId { get; set; }

        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [Display(Name ="Course")]
        public int? CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        [Display(Name ="Name")]
        public string CourseName { get; set; }
        public string Credit { get; set; }
    }
}