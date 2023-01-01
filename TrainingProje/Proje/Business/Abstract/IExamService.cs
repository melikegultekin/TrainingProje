using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IExamService
    {
        void Add(Exam model);

        void Update(int ExamId);

        void Update(Exam model);

        Exam GetById(int id);

        void Delete(int ExamId);
    }
}
