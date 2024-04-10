using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Portal_MVC_Dotnet_core.Data;
using Student_Portal_MVC_Dotnet_core.Models;
using Student_Portal_MVC_Dotnet_core.Models.Entities;

namespace Student_Portal_MVC_Dotnet_core.Controllers;

public class StudentsController : Controller
{

    private readonly ApplicationDBContext _dbContext;
    public StudentsController(ApplicationDBContext dbContext)
    {
        this._dbContext = dbContext;
    }
    // GET
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddStudentViewModel viewModel)
    {
        var student = new Student
        {
            Name = viewModel.Name,
            Email = viewModel.Email,
            PhoneNumber = viewModel.PhoneNumber,
            Subscribed = viewModel.Subscribed
        };

        await _dbContext.Students.AddAsync(student);
        await _dbContext.SaveChangesAsync();
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
       var student =  await _dbContext.Students.ToListAsync();
       return View(student);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var student = await _dbContext.Students.FindAsync(id);
        return View(student);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Student viewModel)
    {
      var student =   await _dbContext.Students.FindAsync(viewModel.Id);

      if (student is not null)
      {
          student.Name = viewModel.Name;
          student.Email = viewModel.Email;
          student.PhoneNumber = viewModel.PhoneNumber;
          student.Subscribed = viewModel.Subscribed;

          await _dbContext.SaveChangesAsync();

          
      }
      return RedirectToAction("List", "Students");
    }
}