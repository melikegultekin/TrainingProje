using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ExamManager : IExamService
    {
        private readonly IExamDal _examDal;

        public ExamManager(IExamDal examDal)
        {
            _examDal = examDal;
        }

        public void Add(Exam model)
        {
            _examDal.Add(model);
        }

        public void Delete(int ExamId)
        {
            _examDal.Delete(ExamId);
        }

        public Exam GetById(int id)
        {
            return _examDal.Get(u => u.ExamId == id);
        }

        public void Update(int ExamId)
        {
            _examDal.Update(ExamId);
        }

        public void Update(Exam model)
        {
            _examDal.Update(model);
        }
    }
}
