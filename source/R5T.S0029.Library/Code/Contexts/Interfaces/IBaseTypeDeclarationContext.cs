using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.S0029.Library
{
    public interface IBaseTypeDeclarationContext<TBaseType>
        where TBaseType : BaseTypeDeclarationSyntax
    {
        NamespaceDeclarationSyntax Namespace { get; }
        TBaseType TypeDeclaration { get; }

        /// <summary>
        /// Will not be null.
        /// </summary>
        ICompilationUnitContext CompilationUnitContext { get; }
    }
}
