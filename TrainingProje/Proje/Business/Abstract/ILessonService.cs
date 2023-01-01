using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ILessonService
    {
        void Add(Lesson model);

        void Update(int lessonId);

        void Update(Lesson model);

        Lesson GetById(int id);

        void Delete(Lesson model);

        void Delete(int lessonId);
    }
}
