using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTrainingDal : EfEntityRepositoryBase<Training, Proje2Context>, ITrainingDal
    {
        //private readonly ITrainingDal _trainingDal;

        public void Delete(int trainingId)
        {
            using (Proje2Context context = new Proje2Context())
            {

                Training deletedEntity = context.Trainings.Where(x => x.TrainingId == trainingId).FirstOrDefault();

                context.Entry(deletedEntity).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public void Update(int trainingId)
        {
            using (Proje2Context context = new Proje2Context())
            {
                var deletedEntity = context.Entry(trainingId);

                deletedEntity.State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public void Add(TrainingDetailDto trainingDetailDto)
        {
            using (Proje2Context context = new Proje2Context())
            {
                var addedEntity = context.Entry(trainingDetailDto);

                addedEntity.State = EntityState.Added;//Ekleme işlemi yapılacağını bildirdik. 

                context.SaveChanges();//İşlemleri gerçekleştir.

            }
        }
    }
}
