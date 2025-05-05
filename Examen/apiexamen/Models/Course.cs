using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiexamen.Models
{
  public class Course
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string? Image { get; set; }
  }
}
