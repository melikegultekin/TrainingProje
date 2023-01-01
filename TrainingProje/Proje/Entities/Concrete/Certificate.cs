using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Certificate : IEntity
    {
        [Key]
        public int CertificateId { get; set; }

        public int UserId { get; set; }

        public int EducatorId { get; set; }

        public int TrainingId { get; set; }

        public int Status { get; set; }
    }
}
