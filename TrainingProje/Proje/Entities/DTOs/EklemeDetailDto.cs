using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class EklemeDetailDto : IDto
    {
        public int EducatorId { get; set; }

        public int TrainingId { get; set; }

        public int LessonId { get; set; }

        public int TitleId { get; set; }

        public int ClassId { get; set; }
    }
}
