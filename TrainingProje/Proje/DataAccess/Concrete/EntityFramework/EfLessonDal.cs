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
    public class EfLessonDal : EfEntityRepositoryBase<Lesson, Proje2Context>, ILessonDal
    {
        public void Delete(int lessonId)
        {
            using (Proje2Context context = new Proje2Context())
            {

                Lesson deletedEntity = context.Lessons.Where(x => x.LessonId == lessonId).FirstOrDefault();

                context.Entry(deletedEntity).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public void Update(int lessonId)
        {
            using (Proje2Context context = new Proje2Context())
            {
                var deletedEntity = context.Entry(lessonId);

                deletedEntity.State = EntityState.Modified;

                context.SaveChanges();
            }
        }
    }
}
