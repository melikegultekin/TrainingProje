using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class TrainingProgramManager : ITrainingProgramService
    {
        private readonly ITrainingProgramDal _trainingProgramDal;

        public TrainingProgramManager(ITrainingProgramDal trainingProgram)
        {
            _trainingProgramDal = trainingProgram;
        }

        public void Add(TrainingProgramDto trainingProgramDto)
        {
            _trainingProgramDal.Add(trainingProgramDto);
        }

        public void Delete(int? trainingProgramId)
        {
            _trainingProgramDal.Delete((int)trainingProgramId);
        }

        public TrainingProgram GetById(int trainingProgramId)
        {
            return _trainingProgramDal.Get(u => u.TrainingProgramId == trainingProgramId);
        }

        public void Update(TrainingProgram model)
        {
            _trainingProgramDal.Update(model);
        }
    }
}
