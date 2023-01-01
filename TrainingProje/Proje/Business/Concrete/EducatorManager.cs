using Business.Abstract;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class EducatorManager : IEducatorService
    {
        private readonly IEducatorDal _educatorDal;

        public EducatorManager(IEducatorDal educatorDal)
        {
            _educatorDal = educatorDal;
        }

        public void Add(Educator educator)
        {
            throw new NotImplementedException();
        }

        public void Delete(Educator educator)
        {
            throw new NotImplementedException();
        }

        public void Delete(int educatorId)
        {
            _educatorDal.Delete(educatorId);
        }

        public void Details(int EducatorId)
        {
            throw new NotImplementedException();
        }

        public Educator GetById(int id)
        {
            return _educatorDal.Get(u => u.EducatorId == id);
        }

        public void LoginE(EducatorForLoginDto educatorForLoginDto)
        {
            Proje2Context projeContext = new Proje2Context();
        }

        public Educator RegisterE(EducatorForRegisterDto edicatorForRegisterDto, string password, string passwordtekrar)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var educator = new Educator
            {
                EUserName = edicatorForRegisterDto.EUserName,
                Email = edicatorForRegisterDto.Email,
                Tc = edicatorForRegisterDto.Tc,
                EducatorFullName = edicatorForRegisterDto.EducatorFullName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                TitleId = edicatorForRegisterDto.TitleId,
                //Status = true
            };
            _educatorDal.Add(educator);
            //return new SuccessDataResult<User>(user, "Kayıt oldu");
            return new Educator();
            
        }

        public void Update(int EducatorId)
        {
            _educatorDal.Update(EducatorId);
        }

        public void Update(Educator model)
        {
            _educatorDal.Update(model);
        }
    }
}
