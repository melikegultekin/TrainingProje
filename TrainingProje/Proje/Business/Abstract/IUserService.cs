using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        User Register(UserForRegisterDto userForRegisterDto, string password, string passwordtekrar);

        User RegisterM(UserForRegisterDto userForRegisterDto, string password, string passwordtekrar);

        void Login(UserForLoginDto userForLoginDto);

        List<User> GetList();

        User GetByUserName(string userName);

        void Add(Waiting waiting);

        void Delete(User model);

        void Delete(int UserId);

        void Update(User model);

        User GetById(int id);

    }
}
