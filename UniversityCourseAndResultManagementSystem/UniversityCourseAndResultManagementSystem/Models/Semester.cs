using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class Semester
    {
        [Key]
        public int SemesterId { get; set; }
        public string SemesterNo { get; set; }
    }
}