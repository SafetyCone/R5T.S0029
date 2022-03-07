using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Magyar;
using R5T.Ostrogothia.Rivet;

using R5T.A0003;
using R5T.D0048.Default;
using R5T.D0077.A002;
using R5T.D0078.A002;
using R5T.D0079.A002;
using R5T.D0081.I001;
using R5T.D0083.I001;
using R5T.D0088.I0002;
using R5T.D0101.I0001;
using R5T.D0101.I001;
using R5T.D0108.I0001;
using R5T.D0108.I001;
using R5T.D0109.I0001;
using R5T.D0109.I001;
using R5T.D0116.A0001;
using R5T.D0117.I001;
using R5T.O0002;
using R5T.T0063;

using IProvidedServiceActionAggregation = R5T.D0088.I0002.IProvidedServiceActionAggregation;
using IRequiredServiceActionAggregation = R5T.D0088.I0002.IRequiredServiceActionAggregation;
using ServicesPlatformRequiredServiceActionAggregation = R5T.A0003.RequiredServiceActionAggregation;


namespace R5T.S0029
{
    public class HostStartup : HostStartupBase
    {
        public override Task ConfigureConfiguration(IConfigurationBuilder configurationBuilder)
        {
            // Do nothing.
        
            return Task.CompletedTask;
        }

        protected override Task ConfigureServices(IServiceCollection services, IProvidedServiceActionAggregation providedServicesAggregation)
        {
            // Inputs.
            var executionSynchronicityProviderAction = Instances.ServiceAction.AddConstructorBasedExecutionSynchronicityProviderAction(Synchronicity.Synchronous);

            var organizationProviderAction = Instances.ServiceAction.AddOrganizationProviderAction(); // Rivet organization.

            var rootOutputDirectoryPathProviderAction = Instances.ServiceAction.AddConstructorBasedRootOutputDirectoryPathProviderAction(@"C:\Temp\Output");

            // Services platform.
            var servicesPlatformRequiredServiceActionAggregation = new ServicesPlatformRequiredServiceActionAggregation
            {
                ConfigurationAction = providedServicesAggregation.ConfigurationAction,
                ExecutionSynchronicityProviderAction = executionSynchronicityProviderAction,
                LoggerAction = providedServicesAggregation.LoggerAction,
                LoggerFactoryAction = providedServicesAggregation.LoggerFactoryAction,
                MachineMessageOutputSinkProviderActions = EnumerableHelper.Empty<IServiceAction<D0099.D002.IMachineMessageOutputSinkProvider>>(),
                MachineMessageTypeJsonSerializationHandlerActions = EnumerableHelper.Empty<IServiceAction<D0098.IMachineMessageTypeJsonSerializationHandler>>(),
                OrganizationProviderAction = organizationProviderAction,
                RootOutputDirectoryPathProviderAction = rootOutputDirectoryPathProviderAction,
            };

            var servicesPlatform = Instances.ServiceAction.AddProvidedServiceActionAggregation(
                servicesPlatformRequiredServiceActionAggregation);

            // Repositories.
            // Extension method base extensions repository.
            var extensionMethodBaseExtensionRepositoryFilePathsProviderAction = Instances.ServiceAction.AddHardCodedExtensionMethodBaseExtensionRepositoryFilePathsProviderAction();

            var fileBasedExtensionMethodBaseExtensionRepositoryAction = Instances.ServiceAction.AddFileBasedExtensionMethodBaseExtensionRepositoryAction(
                extensionMethodBaseExtensionRepositoryFilePathsProviderAction);

            var extensionMethodBaseExtensionRepositoryAction = Instances.ServiceAction.ForwardToIExtensionMethodBaseExtensionRepositoryAction(fileBasedExtensionMethodBaseExtensionRepositoryAction);

            // Extension method base repository.
            var extensionMethodBaseRepositoryFilePathsProviderAction = Instances.ServiceAction.AddHardCodedExtensionMethodBaseRepositoryFilePathsProviderAction();

            var fileBasedExtensionMethodBaseRepositoryAction = Instances.ServiceAction.AddFileBasedExtensionMethodBaseRepositoryAction(
                extensionMethodBaseRepositoryFilePathsProviderAction);

            var extensionMethodBaseRepositoryAction = Instances.ServiceAction.ForwardToIExtensionMethodBaseRepositoryAction(
                fileBasedExtensionMethodBaseRepositoryAction);

            // Project repository.
            var projectRepositoryFilePathsProviderAction = Instances.ServiceAction.AddHardCodedProjectRepositoryFilePathsProviderAction();

            var fileBasedProjectRepositoryAction = Instances.ServiceAction.AddFileBasedProjectRepositoryAction(
                projectRepositoryFilePathsProviderAction);

            var projectRepositoryAction = Instances.ServiceAction.ForwardFileBasedProjectRepositoryToProjectRepositoryAction(
                fileBasedProjectRepositoryAction);

            var repositoryAction = Instances.ServiceAction.AddRepositoryAction(
                extensionMethodBaseExtensionRepositoryAction,
                extensionMethodBaseRepositoryAction,
                projectRepositoryAction);

            // Visual studio.
            var dotnetOperatorActions = Instances.ServiceAction.AddDotnetOperatorActions(
                servicesPlatform.CommandLineOperatorAction,
                servicesPlatform.SecretsDirectoryFilePathProviderAction);
            var visualStudioProjectFileOperatorActions = Instances.ServiceAction.AddVisualStudioProjectFileOperatorActions(
                dotnetOperatorActions.DotnetOperatorAction,
                servicesPlatform.FileNameOperatorAction,
                servicesPlatform.StringlyTypedPathOperatorAction);
            var visualStudioProjectFileReferencesProviderAction = Instances.ServiceAction.AddVisualStudioProjectFileReferencesProviderAction(
                servicesPlatform.StringlyTypedPathOperatorAction);
            var visualStudioSolutionFileOperatorActions = Instances.ServiceAction.AddVisualStudioSolutionFileOperatorActions(
                dotnetOperatorActions.DotnetOperatorAction,
                servicesPlatform.FileNameOperatorAction,
                servicesPlatform.StringlyTypedPathOperatorAction);

            // Services.
            // Level 00.
            var usingDirectivesFormatterActions = Instances.ServiceAction.AddUsingDirectivesFormatterActions();
            
            // Level 01.
            var compilationUnitContextProviderAction = Instances.ServiceAction.AddCompilationUnitContextProviderAction(
                servicesPlatform.StringlyTypedPathOperatorAction,
                visualStudioProjectFileOperatorActions.VisualStudioProjectFileOperatorAction,
                visualStudioProjectFileReferencesProviderAction,
                visualStudioSolutionFileOperatorActions.VisualStudioSolutionFileOperatorAction);

            // Operations-Dependencies.
            var addProjectReferencesToProjectAction = Instances.ServiceAction.AddAddProjectReferencesToProjectAction(
                projectRepositoryAction,
                servicesPlatform.StringlyTypedPathOperatorAction,
                visualStudioProjectFileOperatorActions.VisualStudioProjectFileOperatorAction,
                visualStudioProjectFileReferencesProviderAction,
                visualStudioSolutionFileOperatorActions.VisualStudioSolutionFileOperatorAction);

            // Operations.
            // Level 01
            var o001_AddExtensionMethodBaseFunctionalityToProjectAction = Instances.ServiceAction.AddO001_AddExtensionMethodBaseFunctionalityToProjectAction(
                compilationUnitContextProviderAction,
                repositoryAction,
                usingDirectivesFormatterActions.UsingDirectivesFormatterAction,
                addProjectReferencesToProjectAction);
            var o001a_AddExtensionMethodBaseFunctionalitiesToProjectAction = Instances.ServiceAction.AddO001a_AddExtensionMethodBaseFunctionalitiesToProjectAction(
                compilationUnitContextProviderAction,
                repositoryAction,
                usingDirectivesFormatterActions.UsingDirectivesFormatterAction,
                addProjectReferencesToProjectAction);
            var o999_ScratchAction = Instances.ServiceAction.AddO999_ScratchAction(
                compilationUnitContextProviderAction,
                servicesPlatform.StringlyTypedPathOperatorAction,
                usingDirectivesFormatterActions.UsingDirectivesFormatterAction);

            // Level 02.
            var o000_MainAction = Instances.ServiceAction.AddO000_MainAction(
                o001a_AddExtensionMethodBaseFunctionalitiesToProjectAction);

            // Run.
            services.MarkAsServiceCollectonConfigurationStatement()
                .Run(servicesPlatform.ConfigurationAuditSerializerAction)
                .Run(servicesPlatform.ServiceCollectionAuditSerializerAction)
                //Operations.
                .Run(o000_MainAction)
                .Run(o001_AddExtensionMethodBaseFunctionalityToProjectAction)
                .Run(o999_ScratchAction)
                ;
            
        
            return Task.CompletedTask;
        }

        protected override Task FillRequiredServiceActions(IRequiredServiceActionAggregation requiredServiceActions)
        {
            // Do nothing since none are required.
        
            return Task.CompletedTask;
        }
    }
}