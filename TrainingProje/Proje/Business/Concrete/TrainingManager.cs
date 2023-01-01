using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class TrainingManager : ITrainingService
    {
        private readonly ITrainingDal _trainingDal;
       
        public TrainingManager(ITrainingDal training)
        {
            _trainingDal = training;
        }
        public Training GetById(int id)
        {
            return _trainingDal.Get(u => u.TrainingId == id);
        }

        public List<Training> GetList()
        {
            throw new NotImplementedException();
        }

        public void Add(Training training)
        {
            _trainingDal.Add(training);
        }

        public void Delete(Training training)
        {
            throw new NotImplementedException();
        }

        public void Update(Training model)
        {
            _trainingDal.Update(model);
        }

        public void Delete(int trainingId)
        {
            _trainingDal.Delete(trainingId);
        }

        public void Update(int TrainingId)
        {
            _trainingDal.Update(TrainingId);
        }
    }
}
