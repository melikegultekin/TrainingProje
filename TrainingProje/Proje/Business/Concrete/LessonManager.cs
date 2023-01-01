using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class LessonManager : ILessonService
    {
        private readonly ILessonDal _lessonDal;

        public LessonManager(ILessonDal lessonDal)
        {
            _lessonDal = lessonDal;
        }

        public void Add(Lesson model)
        {
            _lessonDal.Add(model);
        }

        public void Delete(Lesson model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int lessonId)
        {
            _lessonDal.Delete(lessonId);
        }

        public Lesson GetById(int id)
        {
            return _lessonDal.Get(u => u.LessonId == id);
        }

        public void Update(int lessonId)
        {
            _lessonDal.Update(lessonId);
        }

        public void Update(Lesson model)
        {
            _lessonDal.Update(model);
        }
    }
}
