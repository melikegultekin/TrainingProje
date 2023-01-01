using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IAttendanceDal
    {
        void Update(int attendanceId);

        void Update(Attendance model);

        void Delete(int attendanceId);

        Attendance Get(Expression<Func<Attendance, bool>> filter);

        void Add(Attendance attendance);
    }
}
