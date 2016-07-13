namespace InterviewSystem.Web.Routes.Tests
{
    using System.Web.Routing;

    using MvcRouteTester;

    using InterviewSystem.Web.Controllers;

    using NUnit.Framework;

    [TestFixture]
    public class QuestionsRouteTests
    {
        [Test]
        public void TestRouteById()
        {
            const string Url = "/Question/1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<QuestionsController>(c => c.ById(1));
        }
    }
}
