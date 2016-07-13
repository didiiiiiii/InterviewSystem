namespace InterviewSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;

    using Services.Data;

    using ViewModels.Home;

    public class HomeController : BaseController
    {

        public HomeController()
        {
        }

        public ActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
            };

            return this.View(viewModel);
        }

        [Authorize]
        public ActionResult Administration()
        {
            var viewModel = new AdministrationViewModel
            {
            };

            return this.View(viewModel);
        }

        public ActionResult Candidation()
        {
            var viewModel = new CandidationViewModel
            {
            };

           return this.View(viewModel);
        }

        public ActionResult About()
        {
            var viewModel = new AboutViewModel
            {
            };

            return this.View(viewModel);
        }

    }
}
