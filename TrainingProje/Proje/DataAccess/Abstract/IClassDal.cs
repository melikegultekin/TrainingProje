using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IClassDal : IEntityRepository<Class>
    {
        void Update(int classId);

        void Delete(int classId);

        void Update(ClassDto classDto);
    }
}
