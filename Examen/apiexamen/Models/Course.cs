using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiexamen.Models
{
  public class Course
  {
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }

    public string schedule { get; set; }
    public string? imageUrl { get; set; }

    public string professor { get; set; }
  }
}
