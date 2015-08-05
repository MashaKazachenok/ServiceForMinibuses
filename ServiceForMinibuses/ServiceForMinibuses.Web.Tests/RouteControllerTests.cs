using System.Collections.Generic;
using System.Web.Mvc;
using Models;
using Moq;
using NUnit.Framework;
using ServiceForMinibuses.Manager;
using ServiceForMinibuses.Web.Controllers;
using ServiceForMinibuses.Web.Models;


namespace ServiceForMinibuses.Web.Tests
{
      [TestFixture]
    public class RouteControllerTests
    {
            [Test]
          public void CreateRoute_CheckRenderView_NotNull()
          {

              var routeStoreMock = new Mock<IRouteStore>();
              var stopStoreMock = new Mock<IStopStore>();


              var controller = new RouteController(routeStoreMock.Object, stopStoreMock.Object);

              var actionResult = controller.CreateRoute();

              Assert.IsNotNull(actionResult);
          }

            [Test]
            public void Get_CreateRoute_CheckRenderView_ResultView()
            {

                var routeStoreMock = new Mock<IRouteStore>();
                var stopStoreMock = new Mock<IStopStore>();


                var controller = new RouteController(routeStoreMock.Object, stopStoreMock.Object);

                var actionResult = controller.CreateRoute();
                var viewResult = (ViewResult)actionResult;

                Assert.IsInstanceOf<ViewResult>(actionResult);
                Assert.IsInstanceOf<CreateRouteViewModel>(viewResult.Model);
                Assert.AreEqual(viewResult.ViewName, string.Empty);
               
            }

            [Test]
            public void DeleteRoute()
            {
                var routeStoreMock = new Mock<IRouteStore>();
                var stopStoreMock = new Mock<IStopStore>();

                var controller = new RouteController(routeStoreMock.Object, stopStoreMock.Object);

                var actionResult = controller.DeleteRoute(3);
                Assert.IsNotNull(actionResult);
                Assert.IsInstanceOf<RedirectToRouteResult>(actionResult);
                var routeResult = (RedirectToRouteResult)actionResult;
                Assert.IsNotNull(routeResult.RouteValues);
                Assert.AreEqual(routeResult.RouteValues["Action"], "ViewRoutes" );
            }

            [Test]
            public void ViewRoutes()
            {
                var routeStoreMock = new Mock<IRouteStore>();
                var stopStoreMock = new Mock<IStopStore>();

                var controller = new RouteController(routeStoreMock.Object, stopStoreMock.Object);


                var actionResult = controller.ViewRoutes();
                var viewResult = (ViewResult)actionResult;
                Assert.IsInstanceOf<ViewResult>(actionResult);
                Assert.IsInstanceOf<RouteListViewModel>(viewResult.Model);
                Assert.AreEqual(viewResult.ViewName, string.Empty);
               
            }

    }
}
