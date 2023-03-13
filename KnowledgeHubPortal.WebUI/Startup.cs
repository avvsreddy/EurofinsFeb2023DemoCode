using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KnowledgeHubPortal.WebUI.Startup))]
namespace KnowledgeHubPortal.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
