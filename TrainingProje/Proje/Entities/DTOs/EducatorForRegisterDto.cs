using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace Entities.DTOs
{
    public class EducatorForRegisterDto : IDto
    {
        //public EducatorForRegisterDto()
        //{
        //    this.UnvanList = new List<SelectListItem>();
        //    UnvanList.Add(new SelectListItem { Text = "Seçiniz", Value = "" });
        //}

        public int EducatorId { get; set; }

        public string EUserName { get; set; }

        public string Email { get; set; }

        public int Tc { get; set; }

        public string EducatorFullName { get; set; }

        //public bool IsTurkish { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Passwordtekrar { get; set; }

        public int TitleId { get; set; }

    }
}
