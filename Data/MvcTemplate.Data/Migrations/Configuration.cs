namespace InterviewSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using InterviewSystem.Common;
    using InterviewSystem.Data.Models;
    using System.Collections.Generic;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {

            MySeed(context);

            /*  const string AdministratorUserName = "admin@admin.com";
              const string AdministratorPassword = AdministratorUserName;


              if (!context.Roles.Any())
              {
                  // Create admin role
                  var roleStore = new RoleStore<IdentityRole>(context);
                  var roleManager = new RoleManager<IdentityRole>(roleStore);
                  var role = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                  roleManager.Create(role);

                  // Create admin user
                  var userStore = new UserStore<ApplicationUser>(context);
                  var userManager = new UserManager<ApplicationUser>(userStore);
                  var user = new ApplicationUser { UserName = AdministratorUserName, Email = AdministratorUserName };
                  userManager.Create(user, AdministratorPassword);

                  // Assign user to admin role
                  userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);*/
        }

        private void MySeed(ApplicationDbContext context)
        {
            const string InterviewSystemUserPassword = "@Didi*123";

            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                // Create "Administrator" role
                var role = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                roleManager.Create(role);

                // Create "HR" role
                role = new IdentityRole { Name = GlobalConstants.HrRoleName };
                roleManager.Create(role);

                // Create "Senior Developer" role
                role = new IdentityRole { Name = GlobalConstants.SeniorDeveloperRoleName };
                roleManager.Create(role);

                // Create "Support Person" role
                role = new IdentityRole { Name = GlobalConstants.SupportPersonRoleName };
                roleManager.Create(role);

                // Create "Technical Lead" role
                role = new IdentityRole { Name = GlobalConstants.TechnicalLeadRoleName };
                roleManager.Create(role);

                // Create "Candidate" role
                role = new IdentityRole { Name = GlobalConstants.CandidateRoleName };
                roleManager.Create(role);

                // Create  "Administrator" user
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var user = new ApplicationUser { UserName = "admin", Email = "admin@interviewsystem.com" };
                userManager.Create(user, InterviewSystemUserPassword);
                // Assign user to  "Administrator" role
                userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);

                // Create  "HR" user
                user = new ApplicationUser { UserName = "hr", Email = "hr@interviewsystem.com" };
                userManager.Create(user, InterviewSystemUserPassword);
                // Assign user to  "HR" role
                userManager.AddToRole(user.Id, GlobalConstants.HrRoleName);

                // Create  "Senior Developer" user
                user = new ApplicationUser { UserName = "senior", Email = "senior@interviewsystem.com" };
                userManager.Create(user, InterviewSystemUserPassword);
                // Assign user to  "Senior Developer" role
                userManager.AddToRole(user.Id, GlobalConstants.SeniorDeveloperRoleName);

                // Create  "Support Person" user
                user = new ApplicationUser { UserName = "support", Email = "support@interviewsystem.com" };
                userManager.Create(user, InterviewSystemUserPassword);
                
                // Assign user to  "Senior Developer" role
                userManager.AddToRole(user.Id, GlobalConstants.SupportPersonRoleName);

                // Create  "Technical Lead" user
                user = new ApplicationUser { UserName = "technical", Email = "technical@interviewsystem.com" };
                userManager.Create(user, InterviewSystemUserPassword);
                // Assign user to  "Technical Lead" role
                userManager.AddToRole(user.Id, GlobalConstants.TechnicalLeadRoleName);

                context.SaveChanges();

                context.QuestionTypes.Add(new QuestionType { QuestionTypeName = GlobalConstants.QuestionTypeSingleChoice });
                context.QuestionTypes.Add(new QuestionType { QuestionTypeName = GlobalConstants.QuestionTypeMultipleChoice });
                context.SaveChanges();

                context.QuestionLevels.Add(new QuestionLevel { QuestionLevelName = GlobalConstants.QuestionLevelBeginners });
                context.QuestionLevels.Add(new QuestionLevel { QuestionLevelName = GlobalConstants.QuestionLevelIntermediate });
                context.QuestionLevels.Add(new QuestionLevel { QuestionLevelName = GlobalConstants.QuestionLevelAdvanced });
                context.SaveChanges();


                context.Questions.Add(
                    new Question
                    {
                        Content = "What's new in MVC v.5.0 ? ",
                        Weight = 0.4,
                        Level = context.QuestionLevels.SingleOrDefault(g => g.QuestionLevelName == GlobalConstants.QuestionLevelAdvanced),
                        Type = context.QuestionTypes.SingleOrDefault(g => g.QuestionTypeName == GlobalConstants.QuestionTypeMultipleChoice),
                    });
                context.Questions.Add(
                    new Question
                    {
                        Content = "What is the purpose of Attributes in C# ?",
                        Weight = 0.3,
                        Level = context.QuestionLevels.SingleOrDefault(g => g.QuestionLevelName == GlobalConstants.QuestionLevelBeginners),
                        Type = context.QuestionTypes.SingleOrDefault(g => g.QuestionTypeName == GlobalConstants.QuestionTypeSingleChoice),
                    });
                context.Questions.Add(
                    new Question
                    {
                        Content = "What is the difference between authorization and authentication ?",
                        Weight = 0.4,
                        Level = context.QuestionLevels.SingleOrDefault(g => g.QuestionLevelName == GlobalConstants.QuestionLevelBeginners),
                        Type = context.QuestionTypes.SingleOrDefault(g => g.QuestionTypeName == GlobalConstants.QuestionTypeMultipleChoice),
                    });
                context.SaveChanges();
            }
        }
    }
}