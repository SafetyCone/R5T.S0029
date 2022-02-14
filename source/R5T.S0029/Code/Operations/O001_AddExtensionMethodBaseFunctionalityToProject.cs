using System;
using System.Linq;
using System.Threading.Tasks;

using R5T.O0002;
using R5T.T0020;

using LocalData;


namespace R5T.S0029
{
    [OperationMarker]
    public class O001_AddExtensionMethodBaseFunctionalityToProject : IActionOperation
    {
        private IRepository Repository { get; }
        private AddProjectReferencesToProject AddProjectReferencesToProject { get; }


        public O001_AddExtensionMethodBaseFunctionalityToProject(
            IRepository repository,
            AddProjectReferencesToProject addProjectReferencesToProject)
        {
            this.Repository = repository;

            this.AddProjectReferencesToProject = addProjectReferencesToProject;
        }

        public async Task Run()
        {
            // Inputs.
            var projectFilePath = @"C:\Code\DEV\Git\GitHub\SafetyCone\Test\source\Test\Test.csproj";
            var extensionMethodBaseIdentityString = Instances.ExtensionMethodBaseFunctionality.IAnsiColorCode_BlackBackground_R5T_T0089_X001();


            // Run.

            // Get the identity Guid for the identity string.
            var extensionMethodBaseIdentity = Instances.GuidOperator.FromStringStandard(extensionMethodBaseIdentityString);

            // Get the extension method base type for the extension method base functionality.
            var extensionMethodBase = await this.Repository.GetExtensionMethodBaseForExtensionMethodBaseExtension(extensionMethodBaseIdentity);

            // Get the project for the extension method base functionality.
            var projectReferenceIdentity = await this.Repository.ExtensionMethodBaseExtensionRepository
                .GetProjectIdentityForExtensionMethodBaseExtension(extensionMethodBaseIdentity);

            // Add the project reference to the target project using Olympia functionality (add project reference to target project, and all recursive project references to solution of target project).
            await this.AddProjectReferencesToProject.Run(
                projectFilePath,
                projectReferenceIdentity);

            // Add the extension method base type to the Instances class of the target project.
            // Acquire the 

            // What do I want?
            // * Regardless of whether the code file exists or not, given the project file path, and a project directory-relative path to the code file,
            // * If the code file does not exist, use a specified provider to create it.
            // * Now that the code file exists, provide a code file (compilation) context that has easy methods to:
            // 1) Ensure the project has a project reference. If it doesn't, engage the Olympia functionality to add the project reference to the project, and all recursive references to the solution.
            // => Do this at the moment the line of code is called (instead of some batching/delayed behavior).
            // 2) Ensure the code-file (compilation) context has a using-namespace clause.
            // 3) Has extensions for getting class/interface and method contexts.
            // => These extensions all use a base extension that searches through the compilation's nodes and executes a predicate, so space for a predicate.
            // => These contexts all provide the namespace name in which they exist.
            // 4) Separate project file context and code file context, using has-a relationship for each. Provide both WithProjectFileContext and unexpanded types to allow working on a code file without a project.
            // 5) Separate code file context and compilation unit context, using has-a relationship for each. Provide, WithCodeFileContext, WithCodeFileWithProjectFileContext, and unexpanded types to allow working on just a compilation unit, just a code file, and 
            // ? Though why would I want the code file context without the project context?
            // 6) Use provider services to remove friction from requesting service instances for the contexts, allowing contexts to have lots of services.
            // 7) 
            // 8) Shift all names so that the -WithXContext names are the default, and the -WithoutXContext are the specifics.
            // 9) The -WithoutXContext types should intercept calls to add project so that the same code can be used for contexts without X as with X; all the matters is how the context was generated.
            // ? How though, with extension methods?
            // => In creating the context, just don't fill in those context instances! Then let extensions test for whether the context exists, and in the case they do not, do nothing.
            // => OR! Make the methods extensions of IHasProjectFileContext. Yes, that way we can have -With and -Without project file context versions.
            // => No, that would defeat the purpose of having the same code, for whether or not you were in a project file context.
            // => Ok, so then have IProjectFileContext include a methods in its definition to {Add/Remove}ProjectReferenceIdempotent(). Really, that's all we want out of the project file context.
            // => Do *not* make the services used by IProjectFileContext public; just its path data values.
            // * Well we do want the project path to get a code file path... Maybe two different IProjectFileContexts: IProjectContext and IProjectFileContext.
            // * IProjectContext has the methods to Add/Remove, IProjectFileContext extends to include solution file paths and project file path.
            // => Make the ProjectContextProvider service have public services so that the contexts it provides can be provided by extension methods.
            // => Conclusion: just don't fill in the contexts... have extension methods check they exist.

            //  // Include the namespace.
            //  // In the correct spot.
            //  // With the correct property definition.
        }
    }
}
