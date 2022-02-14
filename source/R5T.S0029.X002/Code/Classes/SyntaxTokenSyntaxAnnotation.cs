using System;

using Microsoft.CodeAnalysis;


namespace R5T.S0029.X002
{
    public class SyntaxTokenSyntaxAnnotation : TypedSyntaxAnnotation<SyntaxToken>
    {
        public SyntaxTokenSyntaxAnnotation(SyntaxAnnotation annotation)
            : base(annotation)
        {
        }
    }
}
