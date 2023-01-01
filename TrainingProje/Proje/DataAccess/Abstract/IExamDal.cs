using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IExamDal : IEntityRepository<Exam>
    {
        void Update(int examId);

        void Delete(int ExamId);
    }
}
