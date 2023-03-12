using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NguyenBaDat_2011060185.Startup))]
namespace NguyenBaDat_2011060185
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
