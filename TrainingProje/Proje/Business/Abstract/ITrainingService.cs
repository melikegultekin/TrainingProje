using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITrainingService
    {
        void Add(Training training);

        void Delete(Training training);

        void Delete(int trainingId);

        void Update(int TrainingId);

        void Update(Training model);

        List<Training> GetList();

        Training GetById(int id);

    }
}
