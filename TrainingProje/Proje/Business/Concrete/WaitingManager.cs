using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class WaitingManager : IWaitingService
    {
        IWaitingDal _waitingDal;

        private Waiting waitings = new Waiting();

        public WaitingManager(IWaitingDal waitingDal)
        {
            _waitingDal = waitingDal;
        }

        public void Add(Waiting waiting)
        {
            _waitingDal.Add(waiting);
        }

        public void Delete(int waitingId)
        {
            _waitingDal.Delete(waitingId);
        }


        public Waiting GetById(int id)
        {
            return _waitingDal.Get(u => u.WaitingId == id);
        }

        public void Update(Waiting model)
        {
            _waitingDal.Update(model);
        }
    }
}
