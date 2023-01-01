using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IWaitingDal:IEntityRepository<Waiting>
    {
        void Delete(int waitingId);
    }
}
