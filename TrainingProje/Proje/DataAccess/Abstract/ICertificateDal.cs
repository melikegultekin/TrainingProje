using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface  ICertificateDal : IEntityRepository<Certificate>
    {
        void Update(int certificateId);

        void Delete(int certificateId);
    }
}
