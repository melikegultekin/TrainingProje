using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Attendance : IEntity
    {
        [Key]
        public int AttendanceId { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public int? TrainingProgramDetailId { get; set; }
        public virtual TrainingProgramDetail TrainingProgramDetail { get; set; }

        public string Status { get; set; }

        public int? ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
}
