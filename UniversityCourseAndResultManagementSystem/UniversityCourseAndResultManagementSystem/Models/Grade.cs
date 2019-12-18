using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }
        [Display(Name ="Grade")]
        public string GradeLetter { get; set; }
    }
}