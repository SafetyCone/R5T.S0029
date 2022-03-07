using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.Lombardy;

using R5T.D0116;
using R5T.T0020;

using R5T.S0029.Library;

using LocalData;


namespace R5T.S0029
{
    [OperationMarker]
    public class O999_Scratch : IActionOperation
    {
        #region Static



        #endregion


        private ICompilationUnitContextProvider CompilationUnitContextProvider { get; }
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }
        private IUsingDirectivesFormatter UsingDirectivesFormatter { get; }


        public O999_Scratch(
            ICompilationUnitContextProvider compilationUnitContextProvider,
            IStringlyTypedPathOperator stringlyTypedPathOperator,
            IUsingDirectivesFormatter usingDirectivesFormatter)
        {
            this.CompilationUnitContextProvider = compilationUnitContextProvider;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
            this.UsingDirectivesFormatter = usingDirectivesFormatter;
        }

        public async Task Run()
        {
            //await this.TryProjectFileContext();
            await this.TryCompilationUnitContext();
        }

#pragma warning disable IDE0051 // Remove unused private members

        private async Task TryProjectFileContext()
        {
            var projectFilePath = @"C:\Code\DEV\Git\GitHub\SafetyCone\Test\source\Test\Test.csproj";

            await this.CompilationUnitContextProvider.InModifyCompilationUnitContext(
                projectFilePath,
                Instances.ProjectPathsOperator.GetInstancesCodeFileRelativePath(),
                async compilationUnitContext =>
                {
                    var outputCompilationUnit = compilationUnitContext.CompilationUnit;

                    await compilationUnitContext.EnsureHasProjectReference(
                        Instances.ProjectPath.R5T_A0001());

                    return outputCompilationUnit;
                });
        }

        private async Task TryCompilationUnitContext()
        {
            // Inputs.
            var projectFilePath = @"C:\Code\DEV\Git\GitHub\SafetyCone\Test\source\TestProject\TestProject.csproj";
            var codeFilePath = @"C:\Code\DEV\Git\GitHub\SafetyCone\Test\source\TestProject\Test.cs";

            // Run.
            var projectDirectoryRelativeCodeFilePath = Instances.ProjectPathsOperator.GetProjectDirectoryRelativeFilePath(
                projectFilePath,
                codeFilePath,
                this.StringlyTypedPathOperator);

            // Uncomment to test acquire logic:
            //Instances.FileSystemOperator.DeleteFileOkIfNotExists(codeFilePath);

            await this.CompilationUnitContextProvider.InAcquiredCompilationUnitContext(
                projectFilePath,
                projectDirectoryRelativeCodeFilePath,
                async compilationUnitContext =>
                {
                    var namespaceName = "TestProject";

                    var outputCompilationUnit = compilationUnitContext.CompilationUnit;

                    // Add usings idempotently.
                    outputCompilationUnit = outputCompilationUnit
                        .AddUsings(
                            "System",
                            "System.Threading.Tasks",
                            "R5T.Lombardy",
                            "R5T.T0020",
                            "R5T.S0029.Library",
                            "LocalData",
                            "Microsoft.Extensions.Hosting",
                            "R5T.D0088",
                            "R5T.D0090",
                            // Yes, repeats.
                            "System",
                            "System.Threading.Tasks",
                            "Microsoft.Extensions.Configuration",
                            "Microsoft.Extensions.DependencyInjection",
                            "R5T.Magyar",
                            "R5T.Ostrogothia.Rivet",
                            "R5T.A0003",
                            "R5T.D0048.Default",
                            "R5T.D0077.A002",
                            "R5T.D0078.A002",
                            "R5T.D0079.A002",
                            "R5T.D0081.I001",
                            "R5T.D0083.I001",
                            "R5T.D0088.I0002",
                            "R5T.D0101.I0001",
                            "R5T.D0101.I001",
                            "R5T.D0108.I0001",
                            "R5T.D0108.I001",
                            "R5T.D0109.I0001",
                            "R5T.D0109.I001",
                            "R5T.T0063",
                            "R5T.S0029.Library",
                            // Local namespace name.
                            "TestProject.Library")
                        .AddUsings(
                            ("IProvidedServiceActionAggregation", "R5T.D0088.I0002.IProvidedServiceActionAggregation"),
                            ("ServicesPlatformRequiredServiceActionAggregation", "R5T.A0003.RequiredServiceActionAggregation"),
                            ("IRequiredServiceActionAggregation", "R5T.D0088.I0002.IRequiredServiceActionAggregation"),
                            ("Documentation", "TestProject.Documentation"),
                            ("Instances", "TestProject.Code.Instances"),
                            ("Glossary", "TestProject.Glossary"))
                        ;

                    // Get all usings.
                    outputCompilationUnit = await this.UsingDirectivesFormatter.FormatUsingDirectives(
                        outputCompilationUnit,
                        namespaceName);

                    return outputCompilationUnit;
                },
                compilationUnitContext =>
                {
                    // Do nothing.
                    return Task.FromResult(compilationUnitContext.CompilationUnit.AddUsings(
                        "System",
                        "System.Threading.Tasks"));
                });
        }

#pragma warning restore IDE0051 // Remove unused private members
    }
}
