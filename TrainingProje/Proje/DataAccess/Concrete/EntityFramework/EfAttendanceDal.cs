using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAttendanceDal : EfEntityRepositoryBase<Attendance, Proje2Context>, IAttendanceDal
    {
        public void Delete(int attendanceId)
        {
            using (Proje2Context context = new Proje2Context())
            {

                Attendance deletedEntity = context.Attendance.Where(x => x.AttendanceId == attendanceId).FirstOrDefault();

                context.Entry(deletedEntity).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public void Update(int attendanceId)
        {
            using (Proje2Context context = new Proje2Context())
            {
                var deletedEntity = context.Entry(attendanceId);

                deletedEntity.State = EntityState.Modified;

                context.SaveChanges();
            }
        }
    }
}
