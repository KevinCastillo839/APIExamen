using apiexamen.Data;
using apiexamen.Dtos.Student;
using apiexamen.Mappers;
using apiexamen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiexamen.Controllers
{
  [Route("api/course/{courseId}/students")]
  [ApiController]
  public class StudentController : ControllerBase
  {
    private readonly ApplicationDBContext _context;

    public StudentController(ApplicationDBContext context)
    {
      _context = context;
    }

    // GET: api/course/{courseId}/students
    // Retrieves all students enrolled in a specific course
    [HttpGet]
    public async Task<IActionResult> GetAll(int courseId)
    {
      var students = await _context.Students
        .Where(s => s.courseId == courseId)
        .ToListAsync();

      var studentDtos = students.Select(s => s.ToDto());

      return Ok(studentDtos);
    }

    // POST: api/course/{courseId}/students
    // Creates a new student and associates them with a specific course
    [HttpPost]
    public async Task<IActionResult> Create(int courseId, [FromBody] CreateStudentRequestDto studentDto)
    {
      var course = await _context.Courses.FindAsync(courseId);
      if (course == null)
      {
        return NotFound("Course not found");
      }

      var student = studentDto.ToStudentFromCreateDto();
      student.courseId = courseId;

      await _context.Students.AddAsync(student);
      await _context.SaveChangesAsync();

      // Send a push notification with the student and course names
      var studentName = $"{student.name}";
      var courseName = course.name;

      await FirebaseHelper.SendPushNotificationToTopicAsync(
          topic: "student_notifications",
          title: "New Student Enrolled",
          body: $"Student {studentName} has enrolled in the course {courseName}"
      );

      return CreatedAtAction(nameof(GetById), new { courseId = courseId, id = student.id }, student.ToDto());
    }

    // GET: api/course/{courseId}/students/{id}
    // Retrieves a student by ID within a specific course
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int courseId, int id)
    {
      var student = await _context.Students
        .FirstOrDefaultAsync(s => s.courseId == courseId && s.id == id);

      if (student == null)
      {
        return NotFound();
      }

      return Ok(student.ToDto());
    }

    // PUT: api/course/{courseId}/students/{id}
    // Updates a student's information
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int courseId, int id, [FromBody] UpdateStudentRequestDto studentDto)
    {
      var student = await _context.Students
        .FirstOrDefaultAsync(s => s.courseId == courseId && s.id == id);

      if (student == null)
      {
        return NotFound();
      }

      student.name = studentDto.name;
      student.email = studentDto.email;
      student.phone = studentDto.phone;
      student.courseId = studentDto.courseId;

      await _context.SaveChangesAsync();

      return Ok(student.ToDto());
    }

    // DELETE: api/course/{courseId}/students/{id}
    // Deletes a student by ID from a specific course
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int courseId, int id)
    {
      var student = await _context.Students
        .FirstOrDefaultAsync(s => s.courseId == courseId && s.id == id);

      if (student == null)
      {
        return NotFound();
      }

      _context.Students.Remove(student);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}
