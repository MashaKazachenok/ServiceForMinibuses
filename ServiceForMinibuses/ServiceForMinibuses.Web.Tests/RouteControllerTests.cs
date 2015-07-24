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

    }
}
