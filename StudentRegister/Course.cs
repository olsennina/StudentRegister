using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister
{
    internal class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = "";
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public virtual List <Student> Students { get; set; } = new List<Student>();

    }
}
