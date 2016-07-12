using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(InterviewSystem.Web.Startup))]

namespace InterviewSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
