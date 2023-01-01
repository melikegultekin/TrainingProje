using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Title :IEntity
    {
        [Key]
        public int TitleId { get; set; }

        public string TitleName { get; set; }
    }
}
