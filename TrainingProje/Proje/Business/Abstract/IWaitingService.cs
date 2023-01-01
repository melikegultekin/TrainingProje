using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IWaitingService
    {
        Waiting GetById(int id);

        void Add(Waiting waiting);

        void Update(Waiting model);

        void Delete(int waitingId);
    }
}
