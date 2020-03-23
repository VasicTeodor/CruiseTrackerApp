using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using CruiseTracker.Model;
using CruiseTracker.Service.Interfaces;

namespace CruiseTracker.Service.Services
{
    public class CaptainService : ICaptainService
    {
        public void AddCaptain(Kapetan captain)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                db.Kapetans.Add(captain);
                db.SaveChanges();
            }
        }

        public IEnumerable<Kapetan> GetAllCaptains()
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                return db.Kapetans.Include(k => k.Plovidbas).Include(k => k.Brods).ToList();
            }
        }

        public Kapetan GetCaptain(int captainId)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                return db.Kapetans.Where(c => c.idKapetana == captainId).Include(k => k.Plovidbas).Include(k => k.Brods)
                    .FirstOrDefault();
            }
        }

        public void RemoveCaptain(int captainId)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                db.Kapetans.Remove(GetCaptain(captainId));
                db.SaveChanges();
            }
        }

        public void UpdateCaptain(Kapetan captain)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                db.Kapetans.AddOrUpdate(captain);
                db.SaveChanges();
            }
        }
    }
}