using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.S0029.Library
{
    public class UsingNamespaceDirectiveSyntaxComparerProvider
    {
#pragma warning disable CA1822 // Mark members as static
        public Task<IComparer<UsingNamespaceDirectiveSyntax>> GetComparer(string _)
#pragma warning restore CA1822 // Mark members as static
        {
            var output = AlphabeticalNamespaceDirectiveComparer.Instance;

            return Task.FromResult(output as IComparer<UsingNamespaceDirectiveSyntax>);
        }
    }
}
