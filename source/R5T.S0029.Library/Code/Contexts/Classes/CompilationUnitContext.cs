using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.S0029.Library
{
    public class CompilationUnitContext : ICompilationUnitContext
    {
        public CompilationUnitSyntax CompilationUnit { get; set; }

        public ICodeFileContext CodeFileContext { get; set; }

        /// <inheritdoc/>
        public IProjectFileContext ProjectFileContext => this.CodeFileContext?.ProjectFileContext;
    }
}
