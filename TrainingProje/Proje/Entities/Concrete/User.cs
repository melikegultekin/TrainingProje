using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        [Key]
        public int UserId { get; set; }
        
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public int Tc { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public int Role { get; set; }

        public int? ClassId { get; set; }
        public virtual Class Class { get; set; }

        //public int? WaitingId { get; set; }
    }

    
}
