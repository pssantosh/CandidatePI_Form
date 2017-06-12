using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ARC.PIForm.Web.Startup))]
namespace ARC.PIForm.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
