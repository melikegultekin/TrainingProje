using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTOs
{
    public class UserForLoginDto : IDto
    {
        
        public string UserName { get; set; }

        public string Password { get; set; }

        //public bool RememberMe { get; set; }

        //public string Passwordtekrar { get; set; }
    }
}
