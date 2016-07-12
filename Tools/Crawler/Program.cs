namespace Crawler
{
    using System;
    using AngleSharp;
    using InterviewSystem.Data;
    using InterviewSystem.Data.Common;
    using InterviewSystem.Data.Models;
    using InterviewSystem.Services.Data;

    public static class Program
    {
        public static void Main()
        {
            var db = new ApplicationDbContext();

            var repo = new DbRepository<QuestionType>(db);
            var typesService = new QuestionTypesService(repo);

            var repoLevel = new DbRepository<QuestionLevel>(db);
            var levelsService = new QuestionLevelsService(repoLevel);

            var configuration = Configuration.Default.WithDefaultLoader();
            var browsingContext = BrowsingContext.New(configuration);

       /*     for (int i = 1; i <= 10000; i++)
            {
                var url = $"http://vicove.com/vic-{i}";
                var document = browsingContext.OpenAsync(url).Result;
                var questionContent = document.QuerySelector("#content_box .post-content").TextContent.Trim();
                if (!string.IsNullOrWhiteSpace(questionContent))
                {
                    var categoryName = document.QuerySelector("#content_box .thecategory a").TextContent.Trim();
                    var levelName = document.QuerySelector("#content_box .thelevel a").TextContent.Trim();
                    var category = typesService.EnsureType(categoryName);
                    var level = levelsService.EnsureLevel(levelName);
                    var question = new Question{ Type = category, Content = questionContent };
                    db.Questions.Add(question);
                    db.SaveChanges();
                    Console.WriteLine(i);
                }
            }*/
        }
    }
}
