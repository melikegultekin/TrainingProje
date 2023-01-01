using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICertificateService
    {
        Certificate GetById(int id);

        void Add(Certificate certificate);

        void Update(Certificate model);

        void Delete(int certificateId);
    }
}
