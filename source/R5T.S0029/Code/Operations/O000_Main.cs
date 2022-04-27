using System;
using System.Threading.Tasks;

using R5T.T0020;

using LocalData;


namespace R5T.S0029
{
    [OperationMarker]
    public class O000_Main : IActionOperation
    {
        private O001a_AddExtensionMethodBaseFunctionalitiesToProject O001A_AddExtensionMethodBaseFunctionalitiesToProject { get; }


        public O000_Main(
            O001a_AddExtensionMethodBaseFunctionalitiesToProject o001A_AddExtensionMethodBaseFunctionalitiesToProject)
        {
            this.O001A_AddExtensionMethodBaseFunctionalitiesToProject = o001A_AddExtensionMethodBaseFunctionalitiesToProject;
        }

        public async Task Run()
        {
            // Inputs.
            var projectFilePath = @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.S0030\source\R5T.S0030\R5T.S0030.csproj";
            var namespaceName = Instances.ProjectPathsOperator.GetDefaultProjectNamespaceName(projectFilePath);

            var extensionMethodBaseIdentityStrings =
                new[]
                {
                    Instances.ExtensionMethodBaseFunctionality.INamespacedTypeNameOperator_GetTypeName_R5T_B0003_X001(),
                };
                // Testing
                //new[]
                //{
                //    Instances.ExtensionMethodBaseFunctionality.IAnsiColorCode_BlackBackground_R5T_T0089_X001(),
                //    Instances.ExtensionMethodBaseFunctionality.IMicrosoftExtensionsNamespaceName_DependencyInjection_R5T_T0035_X002(),
                //    Instances.ExtensionMethodBaseFunctionality.IMSBuild_UsingMSBuildWorkspace_R5T_L0012_T001_X002(),
                //};

            // Run.
            await this.O001A_AddExtensionMethodBaseFunctionalitiesToProject.Run(
                projectFilePath,
                namespaceName,
                extensionMethodBaseIdentityStrings);
        }
    }
}
