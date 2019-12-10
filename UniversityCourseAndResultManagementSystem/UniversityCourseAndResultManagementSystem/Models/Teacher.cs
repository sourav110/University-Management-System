using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Please enter teacher Name")]
        [Display(Name = "Name")]
        [StringLength(50)]
        public string TeacherName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please enter valid email")]
        [Column(TypeName = "varchar")]
        //[DataType(DataType.EmailAddress)]
        [Remote("IsEmailExists", "Teachers", ErrorMessage = "Email already exists")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Contact No.")]
        [Display(Name = "Contact No.")]
        [Remote("IsContactNoExists", "Teachers", ErrorMessage = "Contact NO. already exists")]
        public string ContactNo { get; set; }

        [Display(Name = "Designation")]
        public int DesignationId { get; set; }
        [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [Display(Name = "Credit to be taken")]
        [Required(ErrorMessage = "Please enter Credit to be taken")]
        [Range(0, 1000, ErrorMessage ="Credit must be Non-Negative")]
        public string CreditToBeTaken { get; set; }
    }
}