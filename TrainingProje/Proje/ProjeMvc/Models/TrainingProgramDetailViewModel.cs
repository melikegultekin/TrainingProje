using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeMvc.Models
{
    public class TrainingProgramDetailViewModel
    {
        public int TrainingProgramDetailId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public int? EducatorId { get; set; }

        public int? LessonId { get; set; }

        public int? TrainingProgramId { get; set; }

        public int? ClassId { get; set; }
    }
}
