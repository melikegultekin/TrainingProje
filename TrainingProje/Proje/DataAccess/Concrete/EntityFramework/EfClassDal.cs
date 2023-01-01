using System;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfClassDal : EfEntityRepositoryBase<Class, Proje2Context>, IClassDal
    {
        public void Delete(int classId)
        {
            using (Proje2Context context = new Proje2Context())
            {

                Class deletedEntity = context.Classes.Where(x => x.ClassId == classId).FirstOrDefault();

                context.Entry(deletedEntity).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public void Update(int classId)
        {
            using (Proje2Context context = new Proje2Context())
            {
                var deletedEntity = context.Entry(classId);

                deletedEntity.State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public void Update(ClassDto classDto)
        {
            using (Proje2Context context = new Proje2Context())
            {
                var deletedEntity = context.Entry(classDto);

                deletedEntity.State = EntityState.Modified;

                context.SaveChanges();
            }
        }
    }
}
