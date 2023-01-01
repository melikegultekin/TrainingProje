using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTOs
{
    public class ManagerForRegisterDto : IDto
    {
        public string ManagerName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Passwordtekrar { get; set; }
    }
}
