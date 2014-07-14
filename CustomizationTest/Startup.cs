using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomizationTest.Startup))]
namespace CustomizationTest
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
