using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserExams
    {
        public User User { get; set; }
        public List<Exam> Exams { get; set; }
    }
}
