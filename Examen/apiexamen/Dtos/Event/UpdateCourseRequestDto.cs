using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiexamen.Dtos.Event
{
  public class UpdateEventRequestDto
  {
    public string Name { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
  }
}