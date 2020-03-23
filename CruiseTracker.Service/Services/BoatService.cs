using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using CruiseTracker.Model;
using CruiseTracker.Service.Interfaces;

namespace CruiseTracker.Service.Services
{
    public class BoatService : IBoatService
    {
        public void CreateBoat(Brod boat)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                db.Brods.Add(boat);
                db.SaveChanges();
            }
        }

        public IEnumerable<Brod> GetAllBoats()
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                return db.Brods.ToList();
            }
        }

        public Brod GetBoat(int boatId)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                return db.Brods.Where(b => b.idBroda == boatId).FirstOrDefault();
            }
        }

        public void RemoveBoat(int Boat)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                db.Brods.Remove(db.Brods.Where(b => b.idBroda == Boat).FirstOrDefault());
                db.SaveChanges();
            }
        }

        public void UpdateBoat(Brod boat)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                db.Brods.AddOrUpdate(boat);
                db.SaveChanges();
            }
        }
    }
}