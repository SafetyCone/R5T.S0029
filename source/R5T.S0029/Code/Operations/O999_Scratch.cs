using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.Lombardy;

using R5T.T0020;
using R5T.T0125.X0001;

using R5T.S0029.Library;
using R5T.S0029.X002;

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


        public O999_Scratch(
            ICompilationUnitContextProvider compilationUnitContextProvider,
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.CompilationUnitContextProvider = compilationUnitContextProvider;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
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
                    outputCompilationUnit = outputCompilationUnit.GetUsingsAnnotated(out var usingDirectivesAnnotated);

                    if (usingDirectivesAnnotated.Any())
                    {
                        // There is at least one using.
                        var usingNamespaceDirectivesAnnotated = usingDirectivesAnnotated.GetUsingNamespaceDirectives(outputCompilationUnit);

                        // Sort using namespace directives.
                        var usingNamespaceDirectiveBlockLabelProvider = new UsingNamespaceDirectiveBlockLabelProvider();

                        var usingNamespaceDirectiveLabeledListsAnnotated = await usingNamespaceDirectiveBlockLabelProvider.GetUsingNamespaceDirectiveLabeledLists(
                            usingNamespaceDirectivesAnnotated,
                            namespaceName,
                            outputCompilationUnit);

                        var usingNamespaceDirectivesSortOrder = Instances.UsingDirectiveBlockSortOrder.RivetNamespaces();

                        // Check can sort blocks.
                        var anyNamespaceLabelsMissingFromSortOrder = Instances.Operation.AnyLabelsMissingFromSortOrder(
                            usingNamespaceDirectiveLabeledListsAnnotated,
                            usingNamespaceDirectivesSortOrder.BlockLabels);

                        if (anyNamespaceLabelsMissingFromSortOrder)
                        {
                            throw new Exception("Labels were missing from the sort order.");
                        }

                        // Sort blocks.
                        var orderedUsingNamespaceDirectiveLabeledListsAnnotated = Instances.Operation.OrderByLabels(
                            usingNamespaceDirectiveLabeledListsAnnotated,
                            usingNamespaceDirectivesSortOrder.BlockLabels);

                        var usingNamespaceDirectiveComparerProvider = new UsingNamespaceDirectiveSyntaxComparerProvider();

                        foreach (var labeledList in orderedUsingNamespaceDirectiveLabeledListsAnnotated)
                        {
                            var comparer = await usingNamespaceDirectiveComparerProvider.GetComparer(labeledList.Label);

                            labeledList.Items.Sort((x, y) =>
                            {
                                var xUsingDirective = x.GetAnnotatedNode_Typed(outputCompilationUnit);
                                var yUsingDirective = y.GetAnnotatedNode_Typed(outputCompilationUnit);

                                var output = comparer.Compare(
                                    UsingNamespaceDirectiveSyntax.From(xUsingDirective),
                                    UsingNamespaceDirectiveSyntax.From(yUsingDirective));

                                return output;
                            });
                        }

                        // Using name alias directives.
                        var usingNameAliasDirectivesAnnotated = usingDirectivesAnnotated.GetUsingNameAliasDirectives(outputCompilationUnit);

                        var usingNameAliasBlockLabelProvider = new UsingNameAliasDirectiveBlockLabelProvider();

                        var usingNameAliasDirectiveLabeledListsAnnotated = await usingNameAliasBlockLabelProvider.GetUsingNameAliasDirectiveLabeledLists(
                            usingNameAliasDirectivesAnnotated,
                            namespaceName,
                            outputCompilationUnit);

                        var usingNameAliasDirectivesSortOrder = Instances.UsingDirectiveBlockSortOrder.RivetNameAliases();

                        // Check can sort blocks.
                        var anyNameAliasLabelsMissingFromSortOrder = Instances.Operation.AnyLabelsMissingFromSortOrder(
                            usingNameAliasDirectiveLabeledListsAnnotated,
                            usingNameAliasDirectivesSortOrder.BlockLabels);

                        if (anyNamespaceLabelsMissingFromSortOrder)
                        {
                            throw new Exception("Labels were missing from the sort order.");
                        }

                        // Sort blocks.
                        var orderedUsingNameAliasDirectiveLabeledListsAnnotated = Instances.Operation.OrderByLabels(
                            usingNameAliasDirectiveLabeledListsAnnotated,
                            usingNameAliasDirectivesSortOrder.BlockLabels);

                        var usingNameAliasDirectiveComparerProvider = new UsingNameAliasDirectiveSyntaxComparerProvider();

                        foreach (var labeledList in usingNameAliasDirectiveLabeledListsAnnotated)
                        {
                            var comparer = await usingNameAliasDirectiveComparerProvider.GetComparer(labeledList.Label);

                            labeledList.Items.Sort((x, y) =>
                            {
                                var xUsingDirective = x.GetAnnotatedNode_Typed(outputCompilationUnit);
                                var yUsingDirective = y.GetAnnotatedNode_Typed(outputCompilationUnit);

                                var output = comparer.Compare(
                                    UsingNameAliasDirectiveSyntax.From(xUsingDirective),
                                    UsingNameAliasDirectiveSyntax.From(yUsingDirective));

                                return output;
                            });
                        }

                        // Get back to a list of a common type annotation.
                        var orderedUsingDirectiveBlocksAnnotated = orderedUsingNamespaceDirectiveLabeledListsAnnotated
                            .Select(x => x.Items
                                .Cast<UsingDirectiveAnnotation>()
                                .ToArray())
                            .AppendRange(orderedUsingNameAliasDirectiveLabeledListsAnnotated
                                .Select(x => x.Items
                                    .Cast<UsingDirectiveAnnotation>()
                                    .ToArray()))
                            .Now();

                        // Get specific using directive annotations.
                        var firstUsingOfFirstBlockAnnotation= orderedUsingDirectiveBlocksAnnotated.First().First();

                        var firstUsingOfBlockAnnotations = orderedUsingDirectiveBlocksAnnotated.SkipFirst()
                            .Select(x => x.First())
                            .Now();

                        var allOtherUsingAnnotations = orderedUsingDirectiveBlocksAnnotated
                            .SelectMany(x => x.SkipFirst())
                            .Now();

                        // Set usings now so we can test for whether a using is the first syntax node in a file.
                        // Now convert blocks back to an enumerable of usings.
                        var orderedUsingDirectives = orderedUsingDirectiveBlocksAnnotated
                            .SelectMany(x => x
                                .Select(x => x.GetAnnotatedNode_Typed(outputCompilationUnit)))
                            .Now();

                        // Set usings.
                        outputCompilationUnit = outputCompilationUnit.WithUsings(orderedUsingDirectives.ToSyntaxList());

                        // Now modify spacings.
                        var currentFirstUsingOfFirstBlock = outputCompilationUnit.GetAnnotatedNode_Typed(firstUsingOfFirstBlockAnnotation);

                        var newFirstUsingOfFirstBlock = currentFirstUsingOfFirstBlock.EnsureFirstBlockFirstUsingDirectiveLeadingLines();

                        outputCompilationUnit = outputCompilationUnit.ReplaceNode_Better(currentFirstUsingOfFirstBlock, newFirstUsingOfFirstBlock);

                        foreach (var currentFirstUsingOfBlockAnnotation in firstUsingOfBlockAnnotations)
                        {
                            var currentFirstUsingOfBlock = outputCompilationUnit.GetAnnotatedNode_Typed(currentFirstUsingOfBlockAnnotation);

                            var newFirstUsingOfBlock = currentFirstUsingOfBlock.EnsureBlockFirstUsingDirectiveLeadingLines();

                            outputCompilationUnit = outputCompilationUnit.ReplaceNode_Better(currentFirstUsingOfBlock, newFirstUsingOfBlock);
                        }

                        foreach (var currentOtherUsingAnnotation in allOtherUsingAnnotations)
                        {
                            var currentOtherUsing = outputCompilationUnit.GetAnnotatedNode_Typed(currentOtherUsingAnnotation);

                            var newOtherUsing = currentOtherUsing.EnsureBlockBodyDirectiveLeadingLines();

                            outputCompilationUnit = outputCompilationUnit.ReplaceNode_Better(currentOtherUsing, newOtherUsing);
                        }

                        // Delete annotations.
                    }

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
