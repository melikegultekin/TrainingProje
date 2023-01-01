using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITrainingProgramService
    {
        void Add(TrainingProgramDto trainingProgramDto);

        TrainingProgram GetById(int id);

        void Update(TrainingProgram model);

        void Delete(int? trainingProgramId);
    }
}
