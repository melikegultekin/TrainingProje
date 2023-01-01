using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CertificateManager : ICertificateService
    {
        private readonly ICertificateDal _certificateDal;

        public CertificateManager(ICertificateDal certificateDal)
        {
            _certificateDal = certificateDal;
        }

        public void Add(Certificate model)
        {
            _certificateDal.Add(model);
        }

        public void Delete(int certificateId)
        {
            _certificateDal.Delete(certificateId);
        }

        public Certificate GetById(int id)
        {
            return _certificateDal.Get(u => u.CertificateId == id);
        }

        public void Update(Certificate model)
        {
            throw new NotImplementedException();
        }
    }
}
