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
    public class EfExamDal : EfEntityRepositoryBase<Exam, Proje2Context>, IExamDal
    {
        public void Delete(int ExamId)
        {
            using (Proje2Context context = new Proje2Context())
            {

                Exam deletedEntity = context.Exams.Where(x => x.ExamId == ExamId).FirstOrDefault();

                context.Entry(deletedEntity).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public void Update(int examId)
        {
            using (Proje2Context context = new Proje2Context())
            {
                var deletedEntity = context.Entry(examId);

                deletedEntity.State = EntityState.Modified;

                context.SaveChanges();
            }
        }
    }
}
