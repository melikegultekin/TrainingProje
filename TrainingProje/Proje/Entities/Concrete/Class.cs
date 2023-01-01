using System;
using Core.Entities;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Class : IEntity
    {
        [Key]
        public int ClassId { get; set; }

        public string ClassName { get; set; }

        public int TrainingId { get; set; }
        public virtual Training Training { get; set; }

        public int  TrainingProgramId { get; set; }
        public virtual TrainingProgram TrainingProgram{ get; set; }

        public int Kota { get; set; }
    }
}
