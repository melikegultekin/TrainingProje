using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class TrainingProgramDetailDto : IDto
    {
        public int TrainingProgramDetailId { get; set; }

        public int LessonId { get; set; }

        public int TrainingProgramId { get; set; }

        //public string EUserName { get; set; }

        //public DateTime Trainingstartdate { get; set; }

        //public DateTime Traininglastdate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        //public string TrainingName { get; set; }

        public string Description { get; set; }

        public int EducatorId { get; set; }

        //public int ClassId { get; set; }
    }
}
