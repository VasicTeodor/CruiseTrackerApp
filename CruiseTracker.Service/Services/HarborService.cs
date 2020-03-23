using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using CruiseTracker.Model;
using CruiseTracker.Service.Interfaces;

namespace CruiseTracker.Service.Services
{
    public class HarborService : IHarborService
    {
        public void CreateHarbor(Luka harbor)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                db.Lukas.Add(harbor);
                db.SaveChanges();
            }
        }

        public IEnumerable<Luka> GetAllHarbors()
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                return db.Lukas.Include(l => l.Plovidbas).Include(l => l.Destinacija_Koristi_Luku).ToList();
            }
        }

        public Luka GetHarbor(int harborId)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                return db.Lukas.Where(l => l.idLuke == harborId).Include(l => l.Plovidbas)
                    .Include(l => l.Destinacija_Koristi_Luku).FirstOrDefault();
            }
        }

        public void RemoveHarbor(int harborId)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                db.Lukas.Remove(db.Lukas.Where(l => l.idLuke == harborId).Include(l => l.Plovidbas)
                    .Include(l => l.Destinacija_Koristi_Luku).FirstOrDefault());
                db.SaveChanges();
            }
        }

        public void UpdateHarbor(Luka harbor)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                db.Lukas.AddOrUpdate(harbor);
                db.SaveChanges();
            }
        }
    }
}