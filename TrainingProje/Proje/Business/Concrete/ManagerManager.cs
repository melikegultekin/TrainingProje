using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ManagerManager : IManagerService
    {
        IManagerDal _managerDal;

        private Manager managers = new Manager();

        public ManagerManager(IManagerDal managerDal)
        {
            _managerDal = managerDal;
        }

        public Manager LoginM(ManagerForLoginDto managerForLoginDto)
        {
            Proje2Context projeContext = new Proje2Context();

            return new Manager();
        }

        public Manager RegisterM(ManagerForRegisterDto managerForRegisterDto, string password, string passwordtekrar)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var manager = new Manager
            {
                ManagerName = managerForRegisterDto.ManagerName,
                Email = managerForRegisterDto.Email,
                FirstName = managerForRegisterDto.FirstName,
                LastName = managerForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                //Status = true
            };
            _managerDal.Add(manager);
            //return new SuccessDataResult<User>(user, "Kayıt oldu");
            return new Manager();
        }
    }
}
