using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace R5T.S0029.Library
{
    public static class IProjectFileContextExtensions
    {
        public static async Task AddDependencyProjectReferencesByIdentityStrings_Idempotent(this IProjectFileContext projectFileContext,
            IEnumerable<string> projectIdentityStrings)
        {
            var projectFilePaths = await projectFileContext.ProjectRepository.GetProjectFilePaths(projectIdentityStrings);

            await projectFileContext.AddDependencyProjectReferencesByFilePath_Idempotent(
                projectFilePaths.Values);
        }

        public static async Task AddDependencyProjectReferencesByFilePath_Idempotent(this IProjectFileContext projectFileContext,
            IEnumerable<string> projectFilePaths)
        {
            // Add the project reference to the project.
            await projectFileContext.VisualStudioProjectFileOperator.AddProjectReferences(
                projectFileContext.ProjectFilePath,
                projectFilePaths);

            // Add the project reference and all dependency project references to the solution.
            var recursiveProjectReferences = await Instances.ProjectOperator.GetAllRecursiveProjectReferencesInclusive(
                projectFilePaths,
                projectFileContext.VisualStudioProjectFileReferencesProvider);

            await projectFileContext.VisualStudioSolutionFileOperator.AddDependencyProjectReferences(
                projectFileContext.SolutionFilePaths,
                recursiveProjectReferences);
        }

        /// <summary>
        /// Chooses <see cref="AddDependencyProjectReferencesByIdentityStrings_Idempotent(IProjectFileContext, IEnumerable{string})"/> as the default.
        /// </summary>
        public static async Task AddDependencyProjectReferences(this IProjectFileContext projectFileContext,
            IEnumerable<string> projectIdentityStrings)
        {
            await projectFileContext.AddDependencyProjectReferencesByIdentityStrings_Idempotent(
                projectIdentityStrings);
        }

        public static async Task EnsureHasProjectReferences(this IProjectFileContext projectFileContext,
            IEnumerable<string> projectIdentityStrings)
        {
            await projectFileContext.AddDependencyProjectReferencesByIdentityStrings_Idempotent(
                projectIdentityStrings);
        }

        public static async Task EnsureHasProjectReference(this IProjectFileContext projectFileContext,
            string projectIdentityString)
        {
            await projectFileContext.EnsureHasProjectReferences(
                EnumerableHelper.From(projectIdentityString));
        }
    }
}
