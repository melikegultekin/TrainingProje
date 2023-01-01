using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class TitleManager : ITitleService
    {
        private readonly ITitleDal _titleDal;

        public TitleManager(ITitleDal title)
        {
            _titleDal = title;
        }

        public void Add(Title title)
        {
            _titleDal.Add(title);
        }

        public void Delete(Title model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int titleId)
        {
            _titleDal.Delete(titleId);
        }

        public Title GetById(int id)
        {
            return _titleDal.Get(u => u.TitleId == id);
        }

        public void Update(int TitleId)
        {
            _titleDal.Update(TitleId);
        }

        public void Update(Title model)
        {
            _titleDal.Update(model);
        }
    }
}
