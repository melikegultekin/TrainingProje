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
    public class EfTitleDal : EfEntityRepositoryBase<Title, Proje2Context>, ITitleDal
    {
        public void Delete(int titleId)
        {
            using (Proje2Context context = new Proje2Context())
            {

                Title deletedEntity = context.Titles.Where(x => x.TitleId == titleId).FirstOrDefault();

                context.Entry(deletedEntity).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public void Update(int titleId)
        {
            using (Proje2Context context = new Proje2Context())
            {
                var deletedEntity = context.Entry(titleId);

                deletedEntity.State = EntityState.Modified;

                context.SaveChanges();
            }
        }
    }
}
