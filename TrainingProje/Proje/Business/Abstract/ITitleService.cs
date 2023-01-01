using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITitleService
    {
        void Add(Title title);

        void Update(int TitleId);

        void Update(Title model);

        Title GetById(int id);

        void Delete(Title model);

        void Delete(int titleId);
    }
}
