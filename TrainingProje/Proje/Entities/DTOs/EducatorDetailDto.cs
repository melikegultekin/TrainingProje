using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class EducatorDetailDto : IDto
    {
        public int EducatorId { get; set; }

        public string EUserName { get; set; }

        public int Tc { get; set; }

        public string EducatorFullName { get; set; }

        public string Email { get; set; }

        public string TitleName { get; set; }

        public string TrainingName { get; set; }

        public int TrainingId { get; set; }

        public int TrainingProgramId { get; set; }
    }
}
