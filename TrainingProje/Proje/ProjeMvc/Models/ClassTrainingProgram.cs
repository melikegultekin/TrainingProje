using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeMvc.Models
{
    public class ClassTrainingProgram
    {
        public int ClassId { get; set; }

        public int TrainingProgramId { get; set; }
         
        public string TrainingName { get; set; }

        public string ClassName { get; set; }

        public int Kota { get; set; }

        public string Name { get; set; }
    }
}
