using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.Magyar;


namespace R5T.S0029.Library
{
    public static class ICompilationUnitContextProviderExtensions
    {
        public static CodeFileContext GetCodeFileContext(this ICompilationUnitContextProvider compilationUnitContextProvider,
            string[] solutionFilePaths,
            string projectFilePath,
            string codeFilePath)
        {
            var projectFileContext = compilationUnitContextProvider.GetProjectFileContext(
                solutionFilePaths,
                projectFilePath);

            var output = new CodeFileContext
            {
                CodeFilePath = codeFilePath,
                ProjectFileContext = projectFileContext,
            };

            return output;
        }

        /// <summary>
        /// Default uses the code file's project directory relative path.
        /// </summary>
        public static async Task<CodeFileContext> GetCodeFileContext(this ICompilationUnitContextProvider compilationUnitContextProvider,
            string projectFilePath,
            string projectDirectoryRelativeCodeFilePath)
        {
            var codeFilePath = Instances.ProjectPathsOperator.GetFilePathFromProjectDirectoryRelativePath(
                projectFilePath,
                projectDirectoryRelativeCodeFilePath);

            var projectFileContext = await compilationUnitContextProvider.GetProjectFileContext(
                projectFilePath);

            var output = new CodeFileContext
            {
                CodeFilePath = codeFilePath,
                ProjectFileContext = projectFileContext,
            };

            return output;
        }

        public static async Task<CodeFileContext> GetCodeFileContextUsingCodeFilePath(this ICompilationUnitContextProvider compilationUnitContextProvider,
            string projectFilePath,
            string codeFilePath)
        {
            var projectFileContext = await compilationUnitContextProvider.GetProjectFileContext(
                projectFilePath);

            var output = new CodeFileContext
            {
                CodeFilePath = codeFilePath,
                ProjectFileContext = projectFileContext,
            };

            return output;
        }

        public static CompilationUnitContext GetCompilationUnitContext(this ICompilationUnitContextProvider compilationUnitContextProvider,
            string[] solutionFilePaths,
            string projectFilePath,
            string codeFilePath,
            CompilationUnitSyntax compilationUnit)
        {
            var codeFileContext = compilationUnitContextProvider.GetCodeFileContext(
                solutionFilePaths,
                projectFilePath,
                codeFilePath);

            var output = new CompilationUnitContext
            {
                CompilationUnit = compilationUnit,
                CodeFileContext = codeFileContext,
            };

            return output;
        }

        public static async Task<CompilationUnitContext> GetCompilationUnitContext(this ICompilationUnitContextProvider compilationUnitContextProvider,
            string projectFilePath,
            string projectDirectoryRelativeCodeFilePath,
            CompilationUnitSyntax compilationUnit)
        {
            var codeFileContext = await compilationUnitContextProvider.GetCodeFileContext(
                projectFilePath,
                projectDirectoryRelativeCodeFilePath);

            var output = new CompilationUnitContext
            {
                CompilationUnit = compilationUnit,
                CodeFileContext = codeFileContext,
            };

            return output;
        }

        public static ProjectFileContext GetProjectFileContext(this ICompilationUnitContextProvider compilationUnitContextProvider,
            string[] solutionFilePaths,
            string projectFilePath)
        {
            var output = new ProjectFileContext
            {
                ProjectFilePath = projectFilePath,
                SolutionFilePaths = solutionFilePaths,
                ProjectRepository = compilationUnitContextProvider.ProjectRepository,
                VisualStudioProjectFileOperator = compilationUnitContextProvider.VisualStudioProjectFileOperator,
                VisualStudioProjectFileReferencesProvider = compilationUnitContextProvider.VisualStudioProjectFileReferencesProvider,
                VisualStudioSolutionFileOperator = compilationUnitContextProvider.VisualStudioSolutionFileOperator,
            };

            return output;
        }

        public static async Task<ProjectFileContext> GetProjectFileContext(this ICompilationUnitContextProvider compilationUnitContextProvider,
            string projectFilePath)
        {
            var solutionFilePaths = await Instances.SolutionOperator.GetSolutionFilePathsContainingProject(
                projectFilePath,
                compilationUnitContextProvider.StringlyTypedPathOperator,
                compilationUnitContextProvider.VisualStudioSolutionFileOperator);

            var output = compilationUnitContextProvider.GetProjectFileContext(
                solutionFilePaths,
                projectFilePath);

            return output;
        }

        public static async Task InModifyCompilationUnitContext(this ICompilationUnitContextProvider compilationUnitContextProvider,
            string projectFilePath,
            string projectDirectoryRelativeCodeFilePath,
            Func<ICompilationUnitContext, Task<CompilationUnitSyntax>> compilationUnitContextAction = default)
        {
            var (solutionFilePaths, codeFilePath) = await compilationUnitContextProvider.CompilationContextSetup(
                projectFilePath,
                projectDirectoryRelativeCodeFilePath,
                verifyCodeFileExists: true);

            await Instances.CompilationUnitOperator.Modify(
                codeFilePath,
                async compilationUnit =>
                {
                    var compilationUnitContext = compilationUnitContextProvider.GetCompilationUnitContext(
                        solutionFilePaths,
                        projectFilePath,
                        codeFilePath,
                        compilationUnit);

                    var outputCompilationUnit = compilationUnitContextAction is object
                        ? await compilationUnitContextAction(compilationUnitContext)
                        // Else do nothing, return the input.
                        : compilationUnit
                        ;

                    return outputCompilationUnit;
                });
        }

        public static async Task<(string[] solutionFilePaths, string codeFilePath)> CompilationContextSetup(this ICompilationUnitContextProvider compilationUnitContextProvider,
            string projectFilePath,
            string projectDirectoryRelativeCodeFilePath,
            bool verifyProjectFileExists = true,
            bool verifyCodeFileExists = false)
        {
            if(verifyProjectFileExists)
            {
                Instances.FileSystemOperator.VerifyFileExists(projectFilePath);
            }

            var solutionFilePaths = await Instances.SolutionOperator.GetSolutionFilePathsContainingProject(
               projectFilePath,
               compilationUnitContextProvider.StringlyTypedPathOperator,
               compilationUnitContextProvider.VisualStudioSolutionFileOperator);

            var codeFilePath = Instances.ProjectPathsOperator.GetFilePathFromProjectDirectoryRelativePath(
                projectFilePath,
                projectDirectoryRelativeCodeFilePath);

            if(verifyCodeFileExists)
            {
                Instances.FileSystemOperator.VerifyFileExists(codeFilePath);
            }

            return (solutionFilePaths, codeFilePath);
        }

        //public static async Task InModifyCompilationUnitContext(this ICompilationUnitContextProvider compilationUnitContextProvider,
        //    string projectFilePath,
        //    string projectDirectoryRelativeCodeFilePath,
        //    Func<ICompilationUnitContext, Task<CompilationUnitSyntax>> compilationUnitSyntaxAction = default,
        //    Func<ICompilationUnitContext, Task<CompilationUnitSyntax>> constructor = default)
        //{

        //}

        /// <summary>
        /// Allows performing an action in a compilation unit context, supplying only a project file path and a project directory-relative code file path.
        /// If the code file path does not exist, the initial compilation unit context action is run, and the resulting compilation unit provided to the compilation unit context action.
        /// </summary>
        public static async Task InAcquiredCompilationUnitContext(this ICompilationUnitContextProvider compilationUnitContextProvider,
            string projectFilePath,
            string projectDirectoryRelativeCodeFilePath,
            Func<ICompilationUnitContext, Task<CompilationUnitSyntax>> compilationUnitContextAction,
            Func<ICompilationUnitContext, Task<CompilationUnitSyntax>> initialCompilationUnitContextAction)
        {
            var (solutionFilePaths, codeFilePath) = await compilationUnitContextProvider.CompilationContextSetup(
                projectFilePath,
                projectDirectoryRelativeCodeFilePath,
                verifyCodeFileExists: false);

            await Instances.CompilationUnitOperator.ModifyAcquired(
                codeFilePath,
                async compilationUnit =>
                {
                    var compilationUnitContext = compilationUnitContextProvider.GetCompilationUnitContext(
                        solutionFilePaths,
                        projectFilePath,
                        codeFilePath,
                        compilationUnit);

                    var outputCompilationUnit = await compilationUnitContextAction(compilationUnitContext);
                    return outputCompilationUnit;
                },
                async compilationUnit =>
                {
                    var compilationUnitContext = compilationUnitContextProvider.GetCompilationUnitContext(
                        solutionFilePaths,
                        projectFilePath,
                        codeFilePath,
                        compilationUnit);

                    var outputCompilationUnit = await initialCompilationUnitContextAction(compilationUnitContext);
                    return outputCompilationUnit;
                });
        }

        ///// <summary>
        ///// Allows acquiring a class declaration context, either 
        ///// </summary>
        //public static async Task InAcquiredClassDeclarationContext(this ICompilationUnitContextProvider compilationUnitContextProvider,
        //    string projectFilePath,
        //    string projectDirectoryRelativeCodeFilePath,
        //    Func<CompilationUnitSyntax, Task<WasFound<ClassDeclarationSyntax>>> classSelector,
        //    Func<ICompilationUnitContext, Task<CompilationUnitSyntax>> compilationUnitConstructor)
        //{

        //}

        ///// <summary>
        ///// Allows acquiring a class declaration context, either 
        ///// </summary>
        //public static async Task InAcquiredClassDeclarationContext(this ICompilationUnitContextProvider compilationUnitContextProvider,
        //    ICompilationUnitContext compilationUnitContext,
        //    Func<CompilationUnitSyntax, Task<WasFound<ClassDeclarationSyntax>>> classSelector,
        //    Func<ICompilationUnitContext, Task<CompilationUnitSyntax>> compilationUnitConstructor)
        //{

        //}
    }
}
