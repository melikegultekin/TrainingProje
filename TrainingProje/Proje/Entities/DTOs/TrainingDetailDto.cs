using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTOs
{
    public class TrainingDetailDto
    {
        public int TrainingId { get; set; }

        public string TrainingName { get; set; }

        public int LessonId { get; set; }

        public DateTime TrainingStartdate { get; set; }

        public DateTime TrainingLastdate { get; set; }

        public DateTime Trainingdate { get; set; }

        public int kota { get; set; }

        public int TotalHours { get; set; }
    }
}
