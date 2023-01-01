using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IManagerService
    {
        Manager LoginM(ManagerForLoginDto managerForLoginDto);
        Manager RegisterM(ManagerForRegisterDto managerForRegisterDto, string password, string passwordtekrar);
    }
}
