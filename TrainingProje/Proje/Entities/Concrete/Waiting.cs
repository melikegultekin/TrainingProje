using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Waiting : IEntity
    {
        [Key]
        public int WaitingId { get; set; }

        public int? TrainingId { get; set; }
        public virtual Training Training { get; set; }

        public int? LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public int Status { get; set; }

        public string MessageContext { get; set; }

        
    }
}
