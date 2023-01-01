using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTOs
{
    public class AddOrUpdateTrainingProgram
    {
        [Key]
        public int TrainingProgramDetailId { get; set; }

        public int TrainingProgramId { get; set; }

        //public string EUserName { get; set; }

        public int EducatorId { get; set; }

        public int LessonId { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int TrainingId { get; set; }

        public string Description { get; set; }

        //public DateTime Trainingstartdate { get; set; }

        //public DateTime Traininglastdate { get; set; }

        //public string TrainingName { get; set; }

        //public string EducatorFullName { get; set; }

        public int ClassId { get; set; }

        //public string ClassName { get; set; }
    }
}
