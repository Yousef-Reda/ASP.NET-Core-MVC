using ASPDAY2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPDAY2.Controllers
{
    public class InstructorController : Controller
    {
        private readonly ItiContext itiContext;
        public InstructorController(ItiContext Context)
        {
            itiContext = Context;
        }
        public IActionResult Index()
        {
            ICollection<Instructor> instructors = itiContext.Instructors.ToList();
            return View(instructors);
        }
        public IActionResult Details(int id)
        {
            var instrucor = itiContext.Instructors.Where(s => s.InsId == id).Include(s => s.Dept).FirstOrDefault();
            return View(instrucor);
        }
        public IActionResult Save()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                itiContext.Instructors.Add(instructor);
                itiContext.SaveChanges();
                
            }

            return View("Save", instructor);
        }
        public IActionResult Delete(int id)
        {
            var ins = itiContext.Instructors.Where( x=>x.InsId==id).FirstOrDefault();
            var courses = itiContext.InsCourses.Where(c => c.InsId == id).ToList();
            itiContext.InsCourses.RemoveRange(courses);
            itiContext.Instructors.Remove(ins);
            itiContext.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            var instructor = itiContext.Instructors.Where(s=>s.InsId == id).FirstOrDefault();
            return View(instructor);
        }
        [HttpPost]
        public IActionResult Edit(Instructor instructor)
        {
            var CurrentInstructor = itiContext.Instructors.Where(s=>s.InsId==instructor.InsId).FirstOrDefault();
            CurrentInstructor.InsName = instructor.InsName;
            CurrentInstructor.Salary = instructor.Salary;
            CurrentInstructor.DeptId = instructor.DeptId;
            CurrentInstructor.InsDegree = instructor.InsDegree;

            itiContext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
