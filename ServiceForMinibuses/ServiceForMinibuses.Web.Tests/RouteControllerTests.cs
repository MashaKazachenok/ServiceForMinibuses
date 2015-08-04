using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using ServiceForMinibuses.Manager;
using ServiceForMinibuses.Web.Controllers;


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
            public void CreateRoute_CheckRenderView_ResultView()
            {

                var routeStoreMock = new Mock<IRouteStore>();
                var stopStoreMock = new Mock<IStopStore>();


                var controller = new RouteController(routeStoreMock.Object, stopStoreMock.Object);

                var actionResult = controller.CreateRoute();
                Assert.IsInstanceOf<ViewResult>(actionResult);
               
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

    }
}
