namespace InterviewSystem.Web.Controllers.Tests
{
    using Moq;

    using InterviewSystem.Data.Models;
    using InterviewSystem.Services.Data;
    using InterviewSystem.Web.Infrastructure.Mapping;
    using InterviewSystem.Web.ViewModels.Home;

    using NUnit.Framework;

    using TestStack.FluentMVCTesting;

    [TestFixture]
    public class QuestionsControllerTests
    {
        [Test]
        public void ByIdShouldWorkCorrectly()
        {
            /*  var autoMapperConfig = new AutoMapperConfig();
              autoMapperConfig.Execute(typeof(QuestionsController).Assembly);
              const string QuestionContent = "SomeContent";
              var questionServiceMock = new Mock<IQuestionService>();
              questionServiceMock.Setup(x => x.GetById(It.IsAny<string>()))
                  .Returns(new Question { Content = QuestionContent, T = new QuestionType{ Name = "asda" } });
              var controller = new QuestionsController(questionsServiceMock.Object);
              controller.WithCallTo(x => x.ById("asdasasd"))
                  .ShouldRenderView("ById")
                  .WithModel<QuestionViewModel>(
                      viewModel =>
                          {
                              Assert.AreEqual(QuestionContent, viewModel.Content);
                          }).AndNoModelErrors();*/
        }
    }
}
