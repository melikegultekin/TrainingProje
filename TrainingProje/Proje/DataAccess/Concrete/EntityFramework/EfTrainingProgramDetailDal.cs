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
    public class EfTrainingProgramDetailDal : EfEntityRepositoryBase<TrainingProgramDetail, Proje2Context>, ITrainingProgramDetailDal
    {
        public void Delete(int trainingProgramDetailId)
        {
            using (Proje2Context context = new Proje2Context())
            {

                TrainingProgramDetail deletedEntity = context.TrainingProgramDetail.Where(x => x.TrainingProgramDetailId == trainingProgramDetailId).FirstOrDefault();

                context.Entry(deletedEntity).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }
    }
}
