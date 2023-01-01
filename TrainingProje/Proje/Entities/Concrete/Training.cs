using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Training : IEntity
    {
        [Key]
        public int TrainingId { get; set; }

        public string TrainingName { get; set; }

        public DateTime TrainingStartdate { get; set; }

        public DateTime TrainingLastdate { get; set; }

        public DateTime Trainingdate { get; set; }

        public int kota { get; set; }

        public int TotalHours { get; set; }

    }
}
