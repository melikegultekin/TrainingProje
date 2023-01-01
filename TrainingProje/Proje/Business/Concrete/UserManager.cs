using Business.Abstract;
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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        private User users = new User();

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(Waiting waiting)
        {
            _userDal.Add(waiting);
        }

        public void Delete(User model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int UserId)
        {
            _userDal.Delete(UserId);
        }

        public User GetById(int id)
        {
            return _userDal.Get(u => u.UserId == id);
        }




        public User GetByUserName(string userName)
        {
            return _userDal.Get(u => u.UserName == userName);
        }

        public List<User> GetList()
        {
            throw new NotImplementedException();
        }

        public void Login(UserForLoginDto userForLoginDto)
        {
            Proje2Context projeContext = new Proje2Context();
        }

        public User Register(UserForRegisterDto userForRegisterDto, string password, string passwordtekrar)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                UserName = userForRegisterDto.UserName,
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Tc = userForRegisterDto.Tc,
                //Status = true
            };
            _userDal.Add(user);
            //return new SuccessDataResult<User>(user, "Kayıt oldu");
            return new User();
        }

        public User RegisterM(UserForRegisterDto userForRegisterDto, string password, string passwordtekrar)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                UserName = userForRegisterDto.UserName,
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Tc = userForRegisterDto.Tc,
                //Status = true
            };
            _userDal.Add(user);
            return new User();
        }

        public void Update(User model)
        {
            _userDal.Update(model);
        }
    }
}
