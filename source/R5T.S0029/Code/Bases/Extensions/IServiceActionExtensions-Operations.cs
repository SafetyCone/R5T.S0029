using System;

using R5T.Lombardy;

using R5T.D0116;
using R5T.D0117;
using R5T.O0002;
using R5T.T0062;
using R5T.T0063;


namespace R5T.S0029
{
    public static partial class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="O001a_AddExtensionMethodBaseFunctionalitiesToProject"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O001a_AddExtensionMethodBaseFunctionalitiesToProject> AddO001a_AddExtensionMethodBaseFunctionalitiesToProjectAction(this IServiceAction _,
            IServiceAction<ICompilationUnitContextProvider> compilationUnitContextProviderAction,
            IServiceAction<IRepository> repositoryAction,
            IServiceAction<IUsingDirectivesFormatter> usingDirectivesFormatterAction,
            IServiceAction<AddProjectReferencesToProject> addProjectReferencesToProjectAction)
        {
            var serviceAction = _.New<O001a_AddExtensionMethodBaseFunctionalitiesToProject>(services => services.AddO001a_AddExtensionMethodBaseFunctionalitiesToProject(
                compilationUnitContextProviderAction,
                repositoryAction,
                usingDirectivesFormatterAction,
                addProjectReferencesToProjectAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O001_AddExtensionMethodBaseFunctionalityToProject"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O001_AddExtensionMethodBaseFunctionalityToProject> AddO001_AddExtensionMethodBaseFunctionalityToProjectAction(this IServiceAction _,
            IServiceAction<ICompilationUnitContextProvider> compilationUnitContextProviderAction,
            IServiceAction<IRepository> repositoryAction,
            IServiceAction<IUsingDirectivesFormatter> usingDirectivesFormatterAction,
            IServiceAction<AddProjectReferencesToProject> addProjectReferencesToProjectAction)
        {
            var serviceAction = _.New<O001_AddExtensionMethodBaseFunctionalityToProject>(services => services.AddO001_AddExtensionMethodBaseFunctionalityToProject(
                compilationUnitContextProviderAction,
                repositoryAction,
                usingDirectivesFormatterAction,
                addProjectReferencesToProjectAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O000_Main"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O000_Main> AddO000_MainAction(this IServiceAction _,
            IServiceAction<O001a_AddExtensionMethodBaseFunctionalitiesToProject> o001a_AddExtensionMethodBaseFunctionalitiesToProjectAction)
        {
            var serviceAction = _.New<O000_Main>(services => services.AddO000_Main(
                o001a_AddExtensionMethodBaseFunctionalitiesToProjectAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O999_Scratch"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O999_Scratch> AddO999_ScratchAction(this IServiceAction _,
            IServiceAction<ICompilationUnitContextProvider> compilationUnitContextProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<IUsingDirectivesFormatter> usingDirectivesFormatterAction)
        {
            var serviceAction = _.New<O999_Scratch>(services => services.AddO999_Scratch(
                compilationUnitContextProviderAction,
                stringlyTypedPathOperatorAction,
                usingDirectivesFormatterAction));

            return serviceAction;
        }
    }
}