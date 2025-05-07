using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiexamen.Models;
using Microsoft.EntityFrameworkCore;

namespace apiexamen.Data
{
  public class ApplicationDBContext : DbContext
  {
    public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
  }
}
