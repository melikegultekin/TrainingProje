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
    public class EfTrainingProgramDal : EfEntityRepositoryBase<TrainingProgram, Proje2Context>, ITrainingProgramDal
    {
        public void Add(TrainingProgramDto trainingProgramDto)
        {
            using (Proje2Context context = new Proje2Context())
            {
                var addedEntity = context.Entry(trainingProgramDto);

                addedEntity.State = EntityState.Added;//Ekleme işlemi yapılacağını bildirdik. 

                context.SaveChanges();//İşlemleri gerçekleştir.

            }
        }

        public void Delete(int trainingProgramId)
        {
            using (Proje2Context context = new Proje2Context())
            {

                TrainingProgram deletedEntity = context.TrainingPrograms.Where(x => x.TrainingProgramId == trainingProgramId).FirstOrDefault();

                context.Entry(deletedEntity).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public void Update(int trainingProgramId)
        {
            using (Proje2Context context = new Proje2Context())
            {
                var deletedEntity = context.Entry(trainingProgramId);

                deletedEntity.State = EntityState.Modified;

                context.SaveChanges();
            }
        }
    }
}
