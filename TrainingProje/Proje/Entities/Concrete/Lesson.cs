using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Lesson :IEntity
    {
        [Key]
        public int LessonId { get; set; }

        public string LessonName { get; set; }

        public int? TrainingId { get; set; }

        public virtual Training Training { get; set; }

        //public int TrainingProgramId { get; set; }
    }
}
