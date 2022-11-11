using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentRegister
{
    internal class Student
    {


        public int StudentId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string City { get; set; } = "";
        public virtual List<Course> Courses { get; set; } = new List<Course>();

        public override string? ToString()
        {
            return $"Id: {this.StudentId}, Name: {this.FirstName} {this.LastName}, City: {this.City}";
        }

    }
}



