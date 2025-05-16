using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiexamen.Dtos.Course
{
  public class UpdateCourseRequestDto
  {    
    public string name { get; set; }
    public string description { get; set; }

    public string schedule { get; set; }

    public string professor { get; set; }   // Change 'imageUrl' to a file, not a string.
        public IFormFile? File { get; set; } // We receive the file.

  }
}