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
            var newRoute = new Route
            {
                Name = "First"
            };

            // Действие
            _routeStore.AddRoute(newRoute);

            // Утверждение
            // SingleOrDefault vs firstOrDefault
            // Single vs First
            var route = _databaseContext.Set<Route>().SingleOrDefault();
            Assert.IsNotNull(newRoute);
            Assert.AreEqual(newRoute.Name, route.Name);
        }
    }
}


