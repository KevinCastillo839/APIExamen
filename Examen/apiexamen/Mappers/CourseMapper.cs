using apiexamen.Dtos.Course;
using apiexamen.Models;

namespace apiexamen.Mappers
{
  public static class CourseMapper
  {
    public static CourseDto ToDto(this Course courseItem)
    {
      return new CourseDto
      {
        id = courseItem.id,
        name = courseItem.name,
        description = courseItem.description,
        schedule = courseItem.schedule,
        imageUrl = courseItem.imageUrl,
        professor = courseItem.professor,
      };
    }

    public static Course ToCourseFromCreateDto(this CreateCourseRequestDto createUserRequest)
    {
      return new Course
      {
        name = createUserRequest.name,
        description = createUserRequest.description,
        schedule = createUserRequest.schedule,
        professor = createUserRequest.professor,
      };
    }
  }
}