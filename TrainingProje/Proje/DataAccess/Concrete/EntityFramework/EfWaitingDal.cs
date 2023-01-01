using Core.DataAccess;
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
    public class EfWaitingDal : EfEntityRepositoryBase<Waiting, Proje2Context>, IWaitingDal
    {
        public void Delete(int waitingId)
        {
            using (Proje2Context context = new Proje2Context())
            {

                Waiting deletedEntity = context.Waiting.Where(x => x.WaitingId == waitingId).FirstOrDefault();

                context.Entry(deletedEntity).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }
    }
}
