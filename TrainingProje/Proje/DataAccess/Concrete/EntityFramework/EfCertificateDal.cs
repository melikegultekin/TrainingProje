using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCertificateDal : EfEntityRepositoryBase<Certificate, Proje2Context>, ICertificateDal
    {
        public void Delete(int certificateId)
        {
            using (Proje2Context context = new Proje2Context())
            {

                Certificate deletedEntity = context.Certificates.Where(x => x.CertificateId == certificateId).FirstOrDefault();

                context.Entry(deletedEntity).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public void Update(int certificateId)
        {
            using (Proje2Context context = new Proje2Context())
            {
                var deletedEntity = context.Entry(certificateId);

                deletedEntity.State = EntityState.Modified;

                context.SaveChanges();
            }
        }
    }
}
