using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoardGameInventory.Startup))]
namespace BoardGameInventory
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
