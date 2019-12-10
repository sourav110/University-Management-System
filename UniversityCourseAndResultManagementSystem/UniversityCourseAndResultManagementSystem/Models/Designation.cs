using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class Designation
    {
        [Key]
        public int DesignationId { get; set; }
        public string DesignationInfo { get; set; }
    }
}