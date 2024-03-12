using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Product_Authorization.Startup))]
namespace Product_Authorization
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
