using System;
using System.Threading.Tasks;

using R5T.T0020;

using LocalData;


namespace R5T.S0029
{
    [OperationMarker]
    public class O002_RemoveExtensionMethodBaseFunctionalityFromProject : IActionOperation
    {
        public Task Run()
        {
            // Inputs.
            var projectFilePath = @"C:\Code\DEV\Git\GitHub\SafetyCone\Test\source\Test\Test.csproj";
            var extensionMethodBaseFunctionalityIdentityString = Instances.ExtensionMethodBaseFunctionality.IAnsiColorCode_BlackBackground_R5T_T0089_X001();

            // Run.

            // Get the extension method base type for the extension method base functionality.
            // Remove the instance property from the target project's instances class.

            // Get the project for the extension method base functionality.
            // Remove the project reference from the target project.

            // Remove extraneous project references from project/solution using Numurge functionality.

            return Task.CompletedTask;
        }
    }
}
