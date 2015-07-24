using System.Data.Entity;
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
            var routeDbSetMock = new Mock<DbSet<Route>>();
            routeDbSetMock.Setup(x => x.Find(1))
                .Returns(new Route
                {
                    Name = "Gomel-Minsk",
                    Id = 1
                });

            var databaseContextMock = new Mock<IDatabaseContext>();
            databaseContextMock.Setup(x => x.Set<Route>())
                .Returns(routeDbSetMock.Object);

            var routeStore = new RouteStore(databaseContextMock.Object);

            // Действие
            var route = routeStore.GetRouteById(1);

            // Утверждение
            Assert.IsNotNull(route);
            Assert.AreEqual(1, route.Id);
            Assert.AreEqual("Gomel - Minsk", route.Name);
        }
    }
}
