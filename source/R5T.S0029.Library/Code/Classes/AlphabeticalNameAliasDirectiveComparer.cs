using System;
using System.Collections.Generic;

using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.S0029.Library
{
    public class AlphabeticalNameAliasDirectiveComparer : IComparer<UsingNameAliasDirectiveSyntax>
    {
        #region Static

        public static AlphabeticalNameAliasDirectiveComparer Instance { get; } = new();

        #endregion


        public int Compare(UsingNameAliasDirectiveSyntax x, UsingNameAliasDirectiveSyntax y)
        {
            var xNameAlias = x.GetNameAlias();
            var yNameAlias = y.GetNameAlias();

            var output = xNameAlias.CompareTo(yNameAlias);
            return output;
        }
    }
}
