using Core.DataAccess;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Entities.DTOs;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, Proje2Context>, IUserDal
    {
        public void Add(Waiting waiting)
        {
            using (Proje2Context context = new Proje2Context())
            {
                var addedEntity = context.Entry(waiting);

                addedEntity.State = EntityState.Added;//Ekleme işlemi yapılacağını bildirdik. 

                context.SaveChanges();//İşlemleri gerçekleştir.

            }
        }

        public void Delete(int UserId)
        {
            using (Proje2Context context = new Proje2Context())
            {

                User deletedEntity = context.Users.Where(x => x.UserId == UserId).FirstOrDefault();

                context.Entry(deletedEntity).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public void Update(User model)
        {
            using (Proje2Context context = new Proje2Context())
            {
                var deletedEntity = context.Entry(model);

                deletedEntity.State = EntityState.Modified;

                context.SaveChanges();
            }
        }
    }
}
