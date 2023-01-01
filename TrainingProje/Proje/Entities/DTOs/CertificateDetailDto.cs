using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CertificateDetailDto : IDto
    {
        public string TitleName { get; set; }

        public string EducatorFullName { get; set; }

        public string TrainingName { get; set; }
    }
}
