using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Educator : IEntity
    {
        [Key]
        public int EducatorId { get; set; }

        public int Tc { get; set; }

        public string EUserName { get; set; }

        public string EducatorFullName { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Email { get; set; }

        public int TitleId { get; set; }
        public virtual Title Title { get; set; }

    }
}
