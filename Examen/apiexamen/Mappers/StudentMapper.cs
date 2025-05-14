using apiexamen.Dtos.Student;
using apiexamen.Models;

namespace apiexamen.Mappers
{
    public static class StudentMapper
    {
        // Mapea el modelo Student a su correspondiente DTO
        public static StudentDto ToDto(this Student studentItem)
        {
            return new StudentDto
            {
                id = studentItem.id,
                name = studentItem.name,
                email = studentItem.email,  // Aquí mapeamos email correctamente
                phone = studentItem.phone,     // Aquí mapeamos phone correctamente
                courseId = studentItem.courseId,
            };
        }

        // Método para mapear el CreateStudentRequestDto a Student
        public static Student ToStudentFromCreateDto(this CreateStudentRequestDto createStudentRequest)
        {
            return new Student
            {
                name = createStudentRequest.name,
                email = createStudentRequest.email, // Mapear description a email
                phone = createStudentRequest.phone,    // Mapear schedule a phone
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

