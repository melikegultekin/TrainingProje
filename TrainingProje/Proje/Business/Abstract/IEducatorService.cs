using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEducatorService
    {
        Educator RegisterE(EducatorForRegisterDto educatorForRegisterDto, string password, string passwordtekrar);

        void LoginE(EducatorForLoginDto educatorForLoginDto);

        void Add(Educator educator);

        void Update(int EducatorId);

        void Update(Educator model);

        void Delete(Educator educator);

        void Delete(int educatorId);

        Educator GetById(int id);

        void Details(int EducatorId);
    }
}
