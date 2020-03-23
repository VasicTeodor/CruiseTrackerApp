using System;
using System.Collections.Generic;
using CruiseTracker.Model;
using CruiseTracker.Service.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace CruiseTracker.Service.Services
{
    public class CruiseService : ICruiseService
    {
        public void CreateCruise(Plovidba cruise)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                db.Plovidbas.Add(cruise);
                db.SaveChanges();
            }
        }

        public IEnumerable<Plovidba> GetAllCruises()
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                return db.Plovidbas.Include(p => p.Destinacija).Include(p => p.Luka).Include(p => p.Kapetan)
                    .Include(p => p.Kartas).ToList();
            }
        }

        public Plovidba GetCruise(int cruiseId)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                return db.Plovidbas.Where(p => p.brDestinacije == cruiseId).Include(p => p.Destinacija).Include(p => p.Luka).Include(p => p.Kapetan)
                    .Include(p => p.Kartas).FirstOrDefault();
            }
        }

        public void RemoveCruise(int cruiseId)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                db.Plovidbas.Remove(db.Plovidbas.Where(p => p.brPlovidbe == cruiseId).FirstOrDefault());
                db.SaveChanges();
            }
        }

        public void UpdateCruise(Plovidba cruise)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                db.Plovidbas.AddOrUpdate(cruise);
                db.SaveChanges();
            }
        }
    }
}