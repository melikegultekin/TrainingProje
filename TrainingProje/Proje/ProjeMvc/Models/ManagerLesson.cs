using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeMvc.Models
{
    public class ManagerLesson
    {
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }

        public int TrainingId { get; set; }

        public int? LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        public string LessonName { get; set; }

        public DateTime TrainingStartdate { get; set; }

        public DateTime TrainingLastdate { get; set; }
    }
}
