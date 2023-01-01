using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AttendanceManager : IAttendanceService
    {
        private readonly IAttendanceDal _attendanceDal;

        public AttendanceManager(IAttendanceDal attendanceDal)
        {
            _attendanceDal = attendanceDal;
        }

        public void Add(Attendance attendance)
        {
            _attendanceDal.Add(attendance);
        }

        public void Delete(int attendanceId)
        {
            throw new NotImplementedException();
        }

        public Attendance GetById(int id)
        {
            return _attendanceDal.Get(u => u.AttendanceId == id);
        }

        public void Update(Attendance model)
        {
            _attendanceDal.Update(model); 
        }

        public void Update(int AttendanceId)
        {
            _attendanceDal.Update(AttendanceId);
        }
    }
}
