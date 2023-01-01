using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ManagerForLoginDto : IDto
    {
            public string ManagerName { get; set; }

            public string Password { get; set; }
    }
}
