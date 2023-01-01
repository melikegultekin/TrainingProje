using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ClassTrainingProg : IDto
    {
        
        public int ClassId { get; set; }

        public string ClassName { get; set; }
        
        public string Name { get; set; }

        public int TrainingId { get; set; }
        //public virtual Training Training { get; set; }

        public int TrainingProgramId { get; set; }
        
    }
}
