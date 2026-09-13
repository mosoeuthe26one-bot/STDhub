using Microsoft.AspNetCore.Mvc;
using StudentHub.Models;

namespace StudentHub.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>
        {
            new Student
            {
                StudentId = 1,
                FirstName = "John",
                LastName = "Smith",
                EnrollmentDate = new DateTime(2026, 1, 15),
                AcceptedCodeOfConduct = true
            },

            new Student
            {
                StudentId = 2,
                FirstName = "Sarah",
                LastName = "Jones",
                EnrollmentDate = new DateTime(2026, 1, 20),
                AcceptedCodeOfConduct = true
            },

            new Student
            {
                StudentId = 3,
                FirstName = "David",
                LastName = "Brown",
                EnrollmentDate = new DateTime(2026, 2, 3),
                AcceptedCodeOfConduct = false
            }
        };

        public IActionResult Details(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

       

        public IActionResult Index()
        {
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            student.StudentId = students.Max(s => s.StudentId) + 1;

            students.Add(student);

            return RedirectToAction("Index");
        }
    }
}