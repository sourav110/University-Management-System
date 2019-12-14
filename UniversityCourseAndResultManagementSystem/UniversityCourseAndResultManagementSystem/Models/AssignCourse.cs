using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class AssignCourse
    {
        [Key]
        public int AssignId { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        [Display(Name ="Credit to be taken")]
        public string CreditToBeTaken { get; set; }

        [Display(Name = "Remaining Credit")]
        public string RemainingCredit { get; set; }

        [Display(Name = "Course Code")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        [Display(Name ="Name")]
        public string CourseName { get; set; }

        public string CourseCredit { get; set; }

    }
}