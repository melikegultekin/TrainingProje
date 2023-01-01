using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEducatorDal : IEntityRepository<Educator>
    {
        void Update(int educatorId);

        void Delete(int educatorId);
    }
}
