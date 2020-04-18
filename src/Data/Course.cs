using System;
using System.Collections.Generic;

namespace Data
{
    public class Course
    {
        public Course()
        {
            CourseName = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
            Description = "Desc - " + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; }
    }

}
