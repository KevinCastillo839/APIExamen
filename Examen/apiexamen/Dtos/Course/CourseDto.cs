namespace apiexamen.Dtos.Course
{
  public class CourseDto
  {
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }

    public string schedule { get; set; }
    public string? imageUrl { get; set; }

    public string professor { get; set; }
  }
}