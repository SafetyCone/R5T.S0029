using System;

using R5T.D0101;
using R5T.D0108;
using R5T.D0109;
using R5T.T0062;
using R5T.T0063;


namespace R5T.S0029
{
    public static partial class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="Repository"/> implementation of <see cref="IRepository"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IRepository> AddRepositoryAction(this IServiceAction _,
            IServiceAction<IExtensionMethodBaseExtensionRepository> extensionMethodBaseExtensionRepositoryAction,
            IServiceAction<IExtensionMethodBaseRepository> extensionMethodBaseRepositoryAction,
            IServiceAction<IProjectRepository> projectRepositoryAction)
        {
            var serviceAction = _.New<IRepository>(services => services.AddRepository(
                extensionMethodBaseExtensionRepositoryAction,
                extensionMethodBaseRepositoryAction,
                projectRepositoryAction));
            return serviceAction;
        }

        public static IServiceAction<HostStartup> AddHostStartupAction(this IServiceAction _)
        {
            var output = _.New<HostStartup>(services => services.AddHostStartup());

            return output;
        }
    }
}