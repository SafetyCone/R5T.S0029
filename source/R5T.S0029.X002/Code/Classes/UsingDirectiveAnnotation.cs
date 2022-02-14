using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.S0029.X002
{
    public class UsingDirectiveAnnotation : SyntaxNodeSyntaxAnnotation<UsingDirectiveSyntax>
    {
        #region Static

        public static UsingDirectiveAnnotation From(SyntaxAnnotation annotation)
        {
            var output = new UsingDirectiveAnnotation(annotation);
            return output;
        }
        
        #endregion


        public UsingDirectiveAnnotation(SyntaxAnnotation annotation)
            : base(annotation)
        {
        }
    }
}
