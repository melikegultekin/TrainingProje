using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace Entities.Concrete
{
    public class TrainingProgram : IEntity 
    {
        [Key]
        public int TrainingProgramId { get; set; }

        public int TrainingId { get; set; }
        public virtual Training Training { get; set; }

        public int Name { get; set; }

    }
}
