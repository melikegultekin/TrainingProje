using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class EducatorForLoginDto : IDto
    {
        public string EUserName { get; set; }

        public string Password { get; set; }
    }
}
