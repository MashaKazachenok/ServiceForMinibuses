using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Models;
using Moq;
using NUnit.Framework;


namespace ServiceForMinibuses.Manager.EntityFramework.Tests
{
    [TestFixture]
    public class RouteStoreTests
    {

        [Test]
        public void GetById_Found()
        {
            // Подготовка
         /*   var routeDbSetMock = new Mock<DbSet<Route>>();
            routeDbSetMock.Setup(x => x.Find(1))
                .Returns(new Route
                {
                    Name = "Gomel-Minsk",
                    Id = 1
                });
            */
            var routeDbSetMock = new List<Route> 
            { 
                new Route { Name = "Gomel-Minsk",
                    Id = 1}, 
           
            }.AsQueryable(); 

            var mockSet = new Mock<DbSet<Route>>();
            mockSet.As<IQueryable<Route>>().Setup(m => m.Provider).Returns(routeDbSetMock.Provider);
            mockSet.As<IQueryable<Route>>().Setup(m => m.Expression).Returns(routeDbSetMock.Expression);
            mockSet.As<IQueryable<Route>>().Setup(m => m.ElementType).Returns(routeDbSetMock.ElementType);
            mockSet.As<IQueryable<Route>>().Setup(m => m.GetEnumerator()).Returns(routeDbSetMock.GetEnumerator()); 

            var databaseContextMock = new Mock<IDatabaseContext>();
            databaseContextMock.Setup(x => x.Routes)
                .Returns(mockSet.Object);

            var routeStore = new RouteStore(databaseContextMock.Object);

            // Действие
            var route = routeStore.GetRouteById(1);

            // Утверждение
            Assert.IsNotNull(route);
            Assert.AreEqual(1, route.Id);
            Assert.AreEqual("Gomel-Minsk", route.Name);
        }
    }
}
