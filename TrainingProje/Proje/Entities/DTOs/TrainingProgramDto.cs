using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class TrainingProgramDto 
    {
        public int? TrainingProgramId { get; set; }

        public int TrainingId { get; set; }

        public int Name { get; set; }

        public int? ClassId { get; set; }

        public string? ClassName { get; set; }

        public int Kota { get; set; }
    }
}
