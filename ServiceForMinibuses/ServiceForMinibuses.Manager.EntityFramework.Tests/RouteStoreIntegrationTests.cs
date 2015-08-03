using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using Models;
using Moq;
using NUnit.Framework;


namespace ServiceForMinibuses.Manager.EntityFramework.Tests
{
    [TestFixture]
    public class RouteStoreIntegrationTests
    {
        private RouteStore _routeStore;
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

            _routeStore = new RouteStore(_databaseContext);
        }

        [TearDown]
        public void TearDown()
        {
            _databaseContext.Database.Delete();
        }

        [Test]
        public void AddRoute()
        {
            // Подготовка
            var newRoute = new Route
            {
                Name = "First"
            };

            // Действие
            _routeStore.AddRoute(newRoute);

            // Утверждение

            var route = _databaseContext.Set<Route>().SingleOrDefault();
            Assert.IsNotNull(newRoute);
            Assert.AreEqual(newRoute.Name, route.Name);
        }

        [Test]
        public void DeleteRoute()
        {
            // Подготовка
            var newRoute = new Route
            {
                Name = "First",
                Id = 3
            };

            // Действие
            _routeStore.AddRoute(newRoute);
            _routeStore.RemoveRoute(newRoute.Id);

            // Утверждение

            var route = _databaseContext.Set<Route>().SingleOrDefault();
            Assert.IsNull(route);
        }

        [Test]
        public void GetRouteById()
        {
            // Подготовка
            var newRoute = new Route
            {
                Name = "First"
            };

            // Действие
            _routeStore.AddRoute(newRoute);
            var route = _routeStore.GetRouteById(1);
            var route2 = _routeStore.GetRouteById(2);

            // Утверждение

            Assert.AreEqual(newRoute.Name, route.Name);
            Assert.IsNull(route2);
        }

        [Test]
        public void GetRoutes()
        {
            // Подготовка
            var newRoutes = new List<Route>
            {
                new Route
                 {
                Name = "First",
                 Stops = new List<Stop>()
                 {
                     new Stop
                     {Name = "1"},
                      new Stop
                     {Name = "2"},
                      new Stop
                     {Name = "3"}
                 }
                 },
             
                new Route
                 {
                Name = "Second"
           },
            
                new Route
                 {
                Name = "Third"
           }
            };

            // Действие
            foreach (var newRoute in newRoutes)
            {
                _routeStore.AddRoute(newRoute);
            }

            var routes = _routeStore.GetRoutes();

            // Утверждение
            Assert.IsNotNull(routes);
            Assert.AreEqual(newRoutes.Count, routes.Count);
            Assert.AreEqual("1", routes[0].Stops[0].Name);
        }
    }
}


