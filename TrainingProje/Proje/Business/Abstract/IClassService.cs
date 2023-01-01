using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IClassService
    {
        void Add(Class model);

        void Update(int ClassId);

        void Update(ClassDto classDto);

        void Update(Class sınıf);

        Class GetById(int id);

        void Delete(Class model);

        void Delete(int classId);
    }
}
