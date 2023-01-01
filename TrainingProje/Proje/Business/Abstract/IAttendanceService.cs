using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAttendanceService
    {
        Attendance GetById(int id);

        void Add(Attendance attendance);

        void Update(Attendance model);

        void Update(int AttendanceId);

        void Delete(int attendanceId);
    }
}
