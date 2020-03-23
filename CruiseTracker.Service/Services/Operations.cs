using System;
using System.Diagnostics;
using System.Linq;
using CruiseTracker.Model;
using CruiseTracker.Service.Interfaces;

namespace CruiseTracker.Service.Services
{
    public class Operations : IOperations
    {
        public int GetCruisesCountForDestIdAndCapName(string destId, string capName)
        {
            int rVal = 0;
            using (var db = new CruiseTrackerDBEntities())
            {
                try
                {
                    rVal = db.Database
                        .SqlQuery<Int32>($"EXECUTE [dbo].[BrojPlovidbiZaIstuDestinacijuIKapetana] {destId},{capName}")
                        .FirstOrDefault();
                    return rVal;
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e.Message);
                    return rVal;
                }
            }
        }

        public int GetCruisesCountForDestNameAndCapName(string destName, string capName)
        {
            int rVal = 0;
            using (var db = new CruiseTrackerDBEntities())
            {
                try
                {
                    rVal = db.Database
                        .SqlQuery<Int32>($"SELECT * FROM [dbo].[GetCruisesCountForDestinationAndCaptain]('{destName}','{capName}')")
                        .FirstOrDefault();
                    return rVal;
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e.Message);
                    return rVal;
                }
            }
        }
    }
}