using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPDAY2.Models;

public partial class Instructor
{

    [Key]
    public int InsId { get; set; }

    [Required(ErrorMessage = "Instructor Name is required.")]
    [StringLength(100, ErrorMessage = "Instructor Name cannot be longer than 100 characters.")]
    public string? InsName { get; set; }

    [Required(ErrorMessage = "Instructor Degree is required.")]
    [StringLength(50, ErrorMessage = "Degree cannot be longer than 50 characters.")]
    public string? InsDegree { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Salary must be a non-negative value.")]
    public int? Salary { get; set; }

    [Required(ErrorMessage = "Department ID is required.")]
    public int? DeptId { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual Department? Dept { get; set; }

    public virtual ICollection<InsCourse> InsCourses { get; set; } = new List<InsCourse>();
}
