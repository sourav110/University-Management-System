using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Please enter Student Name")]
        [Display(Name = "Name")]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please enter valid email")]
        [Column(TypeName = "varchar")]
        //[Remote("IsEmailExists", "Teachers", ErrorMessage = "Email already exists")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Contact No.")]
        [Display(Name = "Contact No.")]
        //[Remote("IsContactNoExists", "Teachers", ErrorMessage = "Contact NO. already exists")]
        public string ContactNo { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        public DateTime RegistrationDate { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        public string RegNo { get; set; }
    }
}