using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IntelligentFashionDesighner.Startup))]
namespace IntelligentFashionDesighner
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
