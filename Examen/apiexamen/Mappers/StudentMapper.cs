using apiexamen.Dtos.Student;
using apiexamen.Models;

namespace apiexamen.Mappers
{
    public static class StudentMapper
    {
     
        public static StudentDto ToDto(this Student studentItem)
        {
            return new StudentDto
            {
                id = studentItem.id,
                name = studentItem.name,
                email = studentItem.email, 
                phone = studentItem.phone,    
                courseId = studentItem.courseId,
            };
        }

        // CreateStudentRequestDto to Student
        public static Student ToStudentFromCreateDto(this CreateStudentRequestDto createStudentRequest)
        {
            return new Student
            {
                name = createStudentRequest.name,
                email = createStudentRequest.email, 
                phone = createStudentRequest.phone,    
                courseId = createStudentRequest.courseId,
            };
         }
        public static void MapUpdate(this Student student, UpdateStudentRequestDto dto)
        {
            student.name = dto.name;
            student.email = dto.email;
            student.phone = dto.phone;
            student.courseId = dto.courseId;
            }
                }
            }

