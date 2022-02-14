using System;
using System.Collections.Generic;

using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.S0029.Library
{
    public class AlphabeticalNamespaceDirectiveComparer : IComparer<UsingNamespaceDirectiveSyntax>
    {
        #region Static

        public static AlphabeticalNamespaceDirectiveComparer Instance { get; } = new();

        #endregion


        public int Compare(UsingNamespaceDirectiveSyntax x, UsingNamespaceDirectiveSyntax y)
        {
            var xNamespaceName = x.GetNamespaceName();
            var yNamespaceName = y.GetNamespaceName();

            var output = xNamespaceName.CompareTo(yNamespaceName);
            return output;
        }
    }
}
