namespace apiexamen.Dtos.Student
{
  public class StudentDto
  {
    public int id { get; set; }  //primary Key
    public string name { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public string phone { get; set; } = string.Empty;

    public int courseId {get; set;}

  }
}