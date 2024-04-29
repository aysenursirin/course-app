using CourseApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CourseApp.Controllers
{

    // localhost:5000/course
    public class CourseController : Controller
    {
        // action method
        // localhost:5000/course/index => course/index.cshtml
        public IActionResult Index()
        {
            return View();
        }

        // localhost:5000/course/apply
        [HttpGet]
        public IActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Apply(Student student)

        {
            if(ModelState.IsValid){
                Repository.AddStudent(student);
            //model binding
                return View("Thanks",student);
            }
            else{
                return View(student); 
            }
        }


        public IActionResult Details()
        {
            var course = new Course();
            course.Name = "Core Mvc Kursu";
            course.Description = "güzel bir kurs";
            course.IsPublished = true;

            return View(course);
        }

        // localhost:5000/course/list => course/list.cshtml
        public IActionResult List()
        {
            var students = Repository.Students.Where(i=>i.Confirm==true);
            return View(students);
        }
    }
}