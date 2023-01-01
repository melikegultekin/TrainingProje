using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class TrainingProgramDetailManager : ITrainingProgramDetailService
    {
        private readonly ITrainingProgramDetailDal _trainingProgramDetailDal;

        public TrainingProgramDetailManager(ITrainingProgramDetailDal trainingProgramDetail)
        {
            _trainingProgramDetailDal = trainingProgramDetail;
        }

        public void Add(TrainingProgramDetail trainingProgramDetail)
        {
            _trainingProgramDetailDal.Add(trainingProgramDetail);
        }

        public void Delete(int trainingProgramDetailId)
        {
            _trainingProgramDetailDal.Delete(trainingProgramDetailId); ;
        }

        public TrainingProgramDetail GetById(int trainingProgramDetailId)
        {
            return _trainingProgramDetailDal.Get(u => u.TrainingProgramDetailId == trainingProgramDetailId);
        }

        public void Update(TrainingProgramDetail model)
        {
            _trainingProgramDetailDal.Update(model);
        }
    }
}
