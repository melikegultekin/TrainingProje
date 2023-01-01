using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Exam : IEntity
    {
        [Key]
        public int ExamId { get; set; }

        public int? ExamNot { get; set; }

        public int? ClassId { get; set; }
        public virtual Class Class { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public int TrainingId { get; set; }
        public virtual Training Training { get; set; }

        public int Status { get; set; }
    }
}
