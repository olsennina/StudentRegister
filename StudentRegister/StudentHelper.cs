using Microsoft.EntityFrameworkCore;
using StudentRegister.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister
{
    internal static class StudentHelper
    {
        public static void AddStudent()
        {
            var addStudent = new Student();
            Console.WriteLine("To register a new student you have to do the following");
            Console.WriteLine("Enter first name:");
            addStudent.FirstName = Console.ReadLine() ?? "";
            Console.WriteLine("Enter last name:");
            addStudent.LastName = Console.ReadLine() ?? "";
            Console.WriteLine("Enter city:");
            addStudent.City = Console.ReadLine() ?? "";

            Console.WriteLine("The new student is registerd as");
            Console.WriteLine(addStudent.ToString());
            Console.WriteLine("The Id will be updated in menu choice 3. List of students");
            var dbContext = new DbContextStudent();
            dbContext.Add(addStudent);
            dbContext.SaveChanges();
        }
        public static void EditStudent()
        {
            var dbContext = new DbContextStudent();

            foreach (var item in dbContext.Students)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Wich student do you want to edit? Press the Id number");
            int studId = Convert.ToInt32(Console.ReadLine());
            var stud = dbContext.Students.Where(s => s.StudentId == studId).FirstOrDefault<Student>();
            if (stud != null)
            {

                Console.WriteLine("What do you want to edit?");
                Console.WriteLine("1. First name 2. Last name 3. City");
                int edit = 0;
                try
                {
                    edit = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Unavaliable choice");
                }
                switch (edit)
                {
                    case 1:
                        Console.WriteLine("Enter new first name:");
                        stud.FirstName = Console.ReadLine() ?? "";
                        dbContext.SaveChanges();
                        Console.WriteLine("The student is now saved as");
                        Console.WriteLine(stud.ToString());
                        break;
                    case 2:
                        Console.WriteLine("Enter new last name:");
                        stud.LastName = Console.ReadLine() ?? "";
                        dbContext.SaveChanges();
                        Console.WriteLine("The student is now saved as");
                        Console.WriteLine(stud.ToString());
                        break;
                    case 3:
                        Console.WriteLine("Enter new city:");
                        stud.City = Console.ReadLine() ?? "";
                        dbContext.SaveChanges();
                        Console.WriteLine("The student is now saved as");
                        Console.WriteLine(stud.ToString());
                        break;
                    default:
                        break;
                }

            }
            else
            {
                Console.WriteLine("Unavaliable choice");
            }
        }
        public static void AddCourse()
        {

            var dbContext = new DbContextStudent();
            foreach (var item in dbContext.Students)
            {
                Console.WriteLine(item);
            }
            var addCourse = new Course();
            Console.WriteLine("Wich student do you want to register for a course? Press the Id");
            int studId = Convert.ToInt32(Console.ReadLine());
            var stud = dbContext.Students.Where(s => s.StudentId == studId).FirstOrDefault<Student>();
            Console.WriteLine("Wich course do you want to apply?");
            foreach (var item in dbContext.Courses)
            {
                Console.WriteLine($"{item.CourseId}-{item.CourseName}");
            }
            Console.WriteLine("Press the Id to apply the course");

            
            int courseId = Convert.ToInt32(Console.ReadLine());
            var course = dbContext.Courses.Include(c => c.Students).First(c=>c.CourseId== courseId);
            stud.Courses.Add(course);

            Console.WriteLine("The student is now registerd to" );
            Console.WriteLine($"Course: {course.CourseName}");
            dbContext.Add(addCourse);
            dbContext.SaveChanges();
        }
    }
}

