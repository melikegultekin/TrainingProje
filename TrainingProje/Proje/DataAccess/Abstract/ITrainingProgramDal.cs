using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ITrainingProgramDal : IEntityRepository<TrainingProgram>
    {
        void Delete(int trainingProgramId);

        void Update(int trainingProgramId);

        void Add(TrainingProgramDto trainingProgramDto);
    }
}
