using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using CruiseTracker.Model;
using CruiseTracker.Service.Interfaces;

namespace CruiseTracker.Service.Services
{
    public class CargoShipService : ICargoShipService
    {
        public void CreateCargoShip(Teretni cargoShip)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                db.Teretnis.Add(cargoShip);
                db.SaveChanges();
            }
        }

        public IEnumerable<Teretni> GetAllCargoShips()
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                return db.Teretnis.Include(t => t.Firmas).Include(t => t.Brod).ToList();
            }
        }

        public Teretni GetCargoShip(int cargoShipId)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                return db.Teretnis.Where(t => t.idBroda == cargoShipId).Include(t => t.Brod).Include(t => t.Firmas).FirstOrDefault();
            }
        }

        public void RemoveCargoShip(int id)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                db.Teretnis.Remove(db.Teretnis.Where(t => t.idBroda == id).Include(t => t.Firmas)
                    .FirstOrDefault());
                db.SaveChanges();
            }
        }

        public void UpdateCargoShip(Teretni cargoShip)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                db.Teretnis.AddOrUpdate(cargoShip);
                db.SaveChanges();
            }
        }
    }
}