using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ITitleDal : IEntityRepository<Title>
    {
        void Update(int titleId);

        void Delete(int titleId);
    }
}
