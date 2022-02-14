using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.S0029.Library
{
    public class UsingNameAliasDirectiveSyntaxComparerProvider
    {
        public Task<IComparer<UsingNameAliasDirectiveSyntax>> GetComparer(string blockLabel)
        {
            var output = AlphabeticalNameAliasDirectiveComparer.Instance;

            return Task.FromResult(output as IComparer<UsingNameAliasDirectiveSyntax>);
        }
    }
}
