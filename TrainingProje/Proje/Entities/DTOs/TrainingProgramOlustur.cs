using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class TrainingProgramOlustur :IDto
    {
        public int TrainingId { get; set; }

        public int Kota { get; set; }
    }
}
