using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using CruiseTracker.Model;
using CruiseTracker.Service.Interfaces;

namespace CruiseTracker.Service.Services
{
    public class PassengerShipServices : IPassengerShipService
    {
        public void CreatePassengerShip(Putnicki passengerShip)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                db.Putnickis.Add(passengerShip);
                db.SaveChanges();
            }
        }

        public IEnumerable<Putnicki> GetAllPassengerShips()
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                return db.Putnickis.Include(p => p.Brod).ToList();
            }
        }

        public Putnicki GetPassengerShip(int passengerShipId)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                return db.Putnickis.Where(p => p.idBroda == passengerShipId).Include(p => p.Brod).FirstOrDefault();
            }
        }

        public void RemovePassengerShip(int passengerShipId)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                db.Putnickis.Remove(db.Putnickis.Where(p => p.idBroda == passengerShipId).Include(p => p.Brod)
                    .FirstOrDefault());
                db.SaveChanges();
            }
        }

        public void UpdatePassengerShip(Putnicki passengerShip)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                db.Putnickis.AddOrUpdate(passengerShip);
                db.SaveChanges();
            }
        }
    }
}