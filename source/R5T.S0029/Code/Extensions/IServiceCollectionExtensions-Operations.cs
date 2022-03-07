using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Lombardy;

using R5T.D0116;
using R5T.D0117;
using R5T.O0002;
using R5T.T0063;


namespace R5T.S0029
{
    public static partial class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="O001a_AddExtensionMethodBaseFunctionalitiesToProject"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO001a_AddExtensionMethodBaseFunctionalitiesToProject(this IServiceCollection services,
            IServiceAction<ICompilationUnitContextProvider> compilationUnitContextProviderAction,
            IServiceAction<IRepository> repositoryAction,
            IServiceAction<IUsingDirectivesFormatter> usingDirectivesFormatterAction,
            IServiceAction<AddProjectReferencesToProject> addProjectReferencesToProjectAction)
        {
            services
                .Run(compilationUnitContextProviderAction)
                .Run(repositoryAction)
                .Run(usingDirectivesFormatterAction)
                .Run(addProjectReferencesToProjectAction)
                .AddSingleton<O001a_AddExtensionMethodBaseFunctionalitiesToProject>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O001_AddExtensionMethodBaseFunctionalityToProject"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO001_AddExtensionMethodBaseFunctionalityToProject(this IServiceCollection services,
            IServiceAction<ICompilationUnitContextProvider> compilationUnitContextProviderAction,
            IServiceAction<IRepository> repositoryAction,
            IServiceAction<IUsingDirectivesFormatter> usingDirectivesFormatterAction,
            IServiceAction<AddProjectReferencesToProject> addProjectReferencesToProjectAction)
        {
            services
                .Run(compilationUnitContextProviderAction)
                .Run(repositoryAction)
                .Run(usingDirectivesFormatterAction)
                .Run(addProjectReferencesToProjectAction)
                .AddSingleton<O001_AddExtensionMethodBaseFunctionalityToProject>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O000_Main"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO000_Main(this IServiceCollection services,
            IServiceAction<O001a_AddExtensionMethodBaseFunctionalitiesToProject> o001a_AddExtensionMethodBaseFunctionalitiesToProjectAction)
        {
            services
                .Run(o001a_AddExtensionMethodBaseFunctionalitiesToProjectAction)
                .AddSingleton<O000_Main>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O999_Scratch"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO999_Scratch(this IServiceCollection services,
            IServiceAction<ICompilationUnitContextProvider> compilationUnitContextProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<IUsingDirectivesFormatter> usingDirectivesFormatterAction)
        {
            services
                .Run(compilationUnitContextProviderAction)
                .Run(stringlyTypedPathOperatorAction)
                .Run(usingDirectivesFormatterAction)
                .AddSingleton<O999_Scratch>();

            return services;
        }
    }
}