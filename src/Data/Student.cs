using System;
using System.Collections.Generic;

namespace Data
{
    public class Student
    {
        public Student()
        {
            Name = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
            Address = new StudentAddress();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public StudentAddress Address { get; set; }
        public IList<StudentCourse> StudentCourses { get; set; }
    }
}
