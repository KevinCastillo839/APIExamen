using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiexamen.Dtos.Student
{
  public class CreateStudentRequestDto
  {

    public int id { get; set; }  // Primary Key
    public string name { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public string phone { get; set; } = string.Empty;

    public int courseId {get; set;}

  }
}