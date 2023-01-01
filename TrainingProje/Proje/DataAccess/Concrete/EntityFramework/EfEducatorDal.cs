using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfEducatorDal : EfEntityRepositoryBase<Educator, Proje2Context>, IEducatorDal
    {
        public void Delete(int educatorId)
        {
            using (Proje2Context context = new Proje2Context())
            {

                Educator deletedEntity = context.Educators.Where(x => x.EducatorId == educatorId).FirstOrDefault();

                context.Entry(deletedEntity).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public void Update(int educatorId)
        {
            using (Proje2Context context = new Proje2Context())
            {
                var deletedEntity = context.Entry(educatorId);

                deletedEntity.State = EntityState.Modified;

                context.SaveChanges();
            }
        }
    }
}
