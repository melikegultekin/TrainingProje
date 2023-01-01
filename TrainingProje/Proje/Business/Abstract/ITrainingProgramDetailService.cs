using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITrainingProgramDetailService
    {
        void Add(TrainingProgramDetail trainingProgramDetail);

        TrainingProgramDetail GetById(int id);

        void Update(TrainingProgramDetail model);

        void Delete(int trainingProgramDetailId);
    }
}
