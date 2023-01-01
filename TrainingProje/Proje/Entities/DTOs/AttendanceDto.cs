using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class AttendanceDto : IDto
    {
        public int AttendanceId { get; set; }

        public int UserId { get; set; }

        public int ClassId { get; set; }

        public int TrainingProgramDetailId { get; set; }

        public int Status { get; set; }
    }
}
