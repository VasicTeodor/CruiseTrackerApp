using System.Collections.Generic;
using System.Linq;
using CruiseTracker.Model;
using CruiseTracker.Service.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace CruiseTracker.Service.Services
{
    public class DestinationService : IDestinationService
    {
        public void CreateNewDestination(Destinacija destination)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                db.Destinacijas.Add(destination);
                db.SaveChanges();
            }
        }

        public IEnumerable<Destinacija> GetAllDestinations()
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                return db.Destinacijas.Include(d => d.Plovidbas).ToList();
            }
        }

        public Destinacija GetDestination(int destinationId)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                return db.Destinacijas.Where(d => d.brDestinacije == destinationId).Include(d => d.Plovidbas).FirstOrDefault();
            }
        }

        public void RemoveDestination(int destinationID)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                db.Destinacijas.Remove(db.Destinacijas.Where(d => d.brDestinacije == destinationID)
                    .Include(d => d.Plovidbas).FirstOrDefault());
                db.SaveChanges();   
            }
        }

        public void UpdateDestination(Destinacija destination)
        {
            using (var db = new CruiseTrackerDBEntities())
            {
                db.Destinacijas.AddOrUpdate(destination);
                db.SaveChanges();
            }
        }
    }
}