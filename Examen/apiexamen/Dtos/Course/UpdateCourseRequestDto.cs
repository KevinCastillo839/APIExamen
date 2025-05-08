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

    public string professor { get; set; }   // Cambiar 'imageUrl' a un archivo, no una cadena
        public IFormFile? File { get; set; } // Recibimos el archivo

  }
}