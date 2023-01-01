using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class Proje2Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database = Proje2; Trusted_Connection=true");

            //Veri tabanı ve projedeki nesneleri bağlama

        }

        public DbSet<Training> Trainings { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<Waiting> Waiting { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<TrainingProgram> TrainingPrograms { get; set; }

        public DbSet<TrainingProgramDetail> TrainingProgramDetail { get; set; }

        public DbSet<Educator> Educators { get; set; }

        public DbSet<Title> Titles { get; set; }

        public DbSet<Class> Classes { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<Attendance> Attendance { get; set; }

        public DbSet<Certificate> Certificates { get; set; }
    }
}
