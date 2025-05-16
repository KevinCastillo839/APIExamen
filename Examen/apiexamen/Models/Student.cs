using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiexamen.Models
{
public class Student
{
    public int id { get; set; }  
    public string name { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public string phone { get; set; } = string.Empty;

    public int courseId { get; set; }
    public Course course { get; set; } = null!;
}
}