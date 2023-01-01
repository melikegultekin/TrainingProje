using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ITrainingDal : IEntityRepository<Training>
    {
        void Delete(int trainingId);

        void Update(int trainingId);

        void Add(TrainingDetailDto trainingDetailDto);
    }
}
