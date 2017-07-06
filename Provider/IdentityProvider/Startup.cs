using IdentityProvider.Security;
using IdentityProvider.Services;

using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;

using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(IdentityProvider.Startup))]

namespace IdentityProvider
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var factory = new IdentityServerServiceFactory()
                                .UseInMemoryClients(Clients.Get())
                                .UseInMemoryScopes(Scopes.Get());

            factory.Register(new Registration<ICredentialProvider, CredentialProvider>());
            factory.Register(new Registration<IIdentityService, IdentityService>());

            factory.UserService = new Registration<IUserService, LoginUserService>();
            factory.ClientStore = new Registration<IClientStore, IdentityClientStore>();

            var options = new IdentityServerOptions
            {
                RequireSsl = false,
                SigningCertificate = Cert.Load(),
                Factory = factory,
                AuthenticationOptions = new AuthenticationOptions
                {
                    EnablePostSignOutAutoRedirect = true
                }
            };

            app.Map("/identity", idsrvApp =>
            {
                idsrvApp.UseIdentityServer(options);
            });
        }
    }
}
