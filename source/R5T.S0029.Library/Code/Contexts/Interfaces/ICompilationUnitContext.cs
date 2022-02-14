using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.S0029.Library
{
    public interface ICompilationUnitContext : IHasProjectFileContext
    {
        /// <summary>
        /// Read-only. Any operations should return the compilation unit.
        /// </summary>
        CompilationUnitSyntax CompilationUnit { get; }

        /// <summary>
        /// May be null if we are working directly in a compilation unit.
        /// Extensions should check that the instance has a code file context, if not, just do nothing.
        /// </summary>
        ICodeFileContext CodeFileContext { get; }
    }
}
