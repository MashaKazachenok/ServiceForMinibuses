
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Models;
using Moq;
using NUnit.Framework;

namespace ServiceForMinibuses.Manager.EntityFramework.Tests
{
     [TestFixture]
    class StopStoreTests
    {
         [Test]
         public void GetById_Found()
         {
             // Подготовка
             var stopDbSetMock = new List<Stop>
            {
                new Stop
                {
                    Name = "Log",
                    Id = 1
                },

            }.AsQueryable();

             var mockSet = new Mock<DbSet<Stop>>();
             mockSet.As<IQueryable<Stop>>().Setup(m => m.Provider).Returns(stopDbSetMock.Provider);
             mockSet.As<IQueryable<Stop>>().Setup(m => m.Expression).Returns(stopDbSetMock.Expression);
             mockSet.As<IQueryable<Stop>>().Setup(m => m.ElementType).Returns(stopDbSetMock.ElementType);
             mockSet.As<IQueryable<Stop>>().Setup(m => m.GetEnumerator()).Returns(stopDbSetMock.GetEnumerator());

             var databaseContextMock = new Mock<IDatabaseContext>();
             databaseContextMock.Setup(x => x.Stops)
                 .Returns(mockSet.Object);

             var stopStore = new StopStore(databaseContextMock.Object);

             // Действие
             var stop = stopStore.GetStopById(1);

             // Утверждение
             Assert.IsNotNull(stop);
             Assert.AreEqual(1, stop.Id);
             Assert.AreEqual("Log", stop.Name);
         }

         [Test]
         public void AddStop()
         {

             var mockSet = new Mock<DbSet<Stop>>();

             var databaseContextMock = new Mock<IDatabaseContext>();
             databaseContextMock.Setup(x => x.Stops)
                 .Returns(mockSet.Object);
             var stopStore = new StopStore(databaseContextMock.Object);

             var stop = new Stop
             {
                 Name = "First"
             };
            
             // Действие
             stopStore.AddStop(stop);

             // Утверждение
             mockSet.Verify(x => x.Add(It.IsAny<Stop>()));
             databaseContextMock.Verify(x => x.Save());
         }

    }
}
