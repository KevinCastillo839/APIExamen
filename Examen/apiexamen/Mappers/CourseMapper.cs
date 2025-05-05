using apiexamen.Dtos.Event;
using apiexamen.Models;

namespace apiexamen.Mappers
{
  public static class CourseMapper
  {
    public static CourseDto ToDto(this Course eventItem)
    {
      return new CourseDto
      {
        Id = eventItem.Id,
        Name = eventItem.Name,
        Location = eventItem.Location,
        Description = eventItem.Description,
        Date = eventItem.Date,
        Image = eventItem.Image
      };
    }

    public static Course ToCourseFromCreateDto(this CreateCourseRequestDto createUserRequest)
    {
      return new Course
      {
        Name = createUserRequest.Name,
        Location = createUserRequest.Location,
        Description = createUserRequest.Description,
        Date = createUserRequest.Date
      };
    }
  }
}