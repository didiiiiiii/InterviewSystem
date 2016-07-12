namespace InterviewSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using InterviewSystem.Common;
    using InterviewSystem.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}
