using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class Allocation
    {
        [Key]
        public int AllocationId { get; set; }

        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        [Display(Name = "Course")]
        public int? CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        [Display(Name = "Room")]
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }

        [Display(Name = "Day")]
        public int DayId { get; set; }
        [ForeignKey("DayId")]
        public virtual Day Day { get; set; }

        [Display(Name = "From")]
        //[Column(TypeName ="time")]
        //[DataType(DataType.Time)]
        public string FromTime { get; set; }

        [Display(Name = "To")]
        //[Column(TypeName="time")]
        //[DataType(DataType.Time)]
        public string ToTime { get; set; }
    }
}