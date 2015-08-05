
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Models;
using NUnit.Framework;

namespace ServiceForMinibuses.Manager.EntityFramework.Tests
{
      [TestFixture]
    class StopStoreIntegrationTests
    {
        private StopStore _stopStore;
        private DatabaseContext _databaseContext;

        [SetUp]
        public void SetUp()
        {
            _databaseContext = new DatabaseContext("DefaultConnection");

            if (_databaseContext.Database.Exists())
            {
                _databaseContext.Database.Delete();
            }

            _databaseContext.Database.Create();

            _stopStore = new StopStore(_databaseContext);
        }

        [TearDown]
        public void TearDown()
        {
            _databaseContext.Database.Delete();
        }

          [Test]
          public void GetStops()
          {
              // Подготовка
              var newStopes = new List<Stop>
            {
                new Stop
                 {
                Name = "First"
                 
                 },
             
                new Stop
                 {
                Name = "Second"
           },
            
                new Stop
                 {
                Name = "Third"
           }
            };

              // Действие
              foreach (var newStop in newStopes)
              {
                  _stopStore.AddStop(newStop);
              }

              var stops = _stopStore.GetStops();

              // Утверждение
              Assert.IsNotNull(stops);
              Assert.AreEqual(newStopes.Count, stops.Count);
          }

          [Test]
          public void UpdateStop()
          {
              // Подготовка
              var newStop = new Stop
              {
                  Name = "One"
              };
              _stopStore.AddStop(newStop);
              var findStop =  _stopStore.GetStopById(1);
              findStop.Name = "Two";

              // Действие
               var databaseContext2 = new DatabaseContext("DefaultConnection");
               _stopStore.UpdateStop(findStop);

              // Утверждение
               var stop = databaseContext2.Set<Stop>().SingleOrDefault();
              Assert.IsNotNull(stop);
              Assert.AreEqual(stop.Name, "Two");
          }
    }
}
