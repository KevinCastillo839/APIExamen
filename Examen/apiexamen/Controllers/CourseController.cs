using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiexamen.Data;
using apiexamen.Dtos.Course;
using apiexamen.Mappers;
using apiexamen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
  [Route("api/course")]
  [ApiController]
  public class CourseController : ControllerBase
  {
    private readonly ApplicationDBContext _context;
    private readonly string _imagePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedImages");
    
    public CourseController(ApplicationDBContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var courses = await _context.Courses.ToListAsync();
      var coursesDto = courses.Select(courses => courses.ToDto());
      return Ok(coursesDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> getById([FromRoute] int id)
    {
      var _course = await _context.Courses.FirstOrDefaultAsync(u => u.id == id);
      if (_course == null)
      {
        return NotFound();
      }
      return Ok(_course.ToDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateCourseRequestDto courseDto)
    {
      if (courseDto.File == null || courseDto.File.Length == 0)
        return BadRequest("No file uploaded.");

      var courseModel = courseDto.ToCourseFromCreateDto();
      await _context.Courses.AddAsync(courseModel);
      await _context.SaveChangesAsync();

      var fileName = courseModel.id.ToString() + Path.GetExtension(courseDto.File.FileName);
      var filePath = Path.Combine(_imagePath, fileName);

      using (var stream = new FileStream(filePath, FileMode.Create))
      {
        await courseDto.File.CopyToAsync(stream);
      }

      courseModel.imageUrl = fileName;
      _context.Courses.Update(courseModel);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(getById), new { id = courseModel.id }, courseModel.ToDto());
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromForm] UpdateCourseRequestDto courseDto)
    {
      var courseModel = await _context.Courses.FirstOrDefaultAsync(_course => _course.id == id);
      if (courseModel == null)
      {
        return NotFound();
      }

      // Update course information
      courseModel.name = courseDto.name;
      courseModel.description = courseDto.description;
      courseModel.schedule = courseDto.schedule;
      courseModel.professor = courseDto.professor;

      // Check if a new image has been uploaded
      if (courseDto.File != null && courseDto.File.Length > 0)
      {
        // Delete the old image if it exists
        if (!string.IsNullOrEmpty(courseModel.imageUrl))
        {
          var oldFilePath = Path.Combine(_imagePath, courseModel.imageUrl);
          if (System.IO.File.Exists(oldFilePath))
          {
            System.IO.File.Delete(oldFilePath);
          }
        }

        // Save the new image
        var fileName = courseModel.id.ToString() + Path.GetExtension(courseDto.File.FileName);
        var filePath = Path.Combine(_imagePath, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
          await courseDto.File.CopyToAsync(stream);
        }

        // Update the image URL in the database
        courseModel.imageUrl = fileName;
      }

      // Save changes
      await _context.SaveChangesAsync();

      return Ok(courseModel.ToDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      var courseModel = await _context.Courses.FirstOrDefaultAsync(_course => _course.id == id);
      if (courseModel == null)
      {
        return NotFound();
      }
      _context.Courses.Remove(courseModel);

      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}
