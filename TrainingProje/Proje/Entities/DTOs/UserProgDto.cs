using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserProgDto :IDto
    {
        public int WaitingId { get; set; }

        public int ClassId { get; set; }

        public int UserId { get; set; }
    }
}

