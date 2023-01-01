using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class TrainingProgramDetail : IEntity
    {
        [Key]
        public int TrainingProgramDetailId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public int? EducatorId { get; set; }
        public virtual Educator Educator { get; set; }

        public int? LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        public int? TrainingProgramId { get; set; }
        public virtual TrainingProgram TrainingProgram { get; set; }
    }
}
