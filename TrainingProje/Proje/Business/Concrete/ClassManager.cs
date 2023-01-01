using System;
using Business.Abstract;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ClassManager : IClassService
    {
        private readonly IClassDal _classDal;

        public ClassManager(IClassDal classDal)
        {
            _classDal = classDal;
        }

        public void Add(Class model)
        {
            _classDal.Add(model);
        }

        public void Delete(Class model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int classId)
        {
            _classDal.Delete(classId);
        }

        public Class GetById(int id)
        {
            return _classDal.Get(u => u.ClassId == id);
        }

        public void Update(int ClassId)
        {
            _classDal.Update(ClassId);
        }

        public void Update(ClassDto classDto)
        {
            _classDal.Update(classDto);
        }

        public void Update(Class sınıf)
        {
            _classDal.Update(sınıf);
        }
    }
}
