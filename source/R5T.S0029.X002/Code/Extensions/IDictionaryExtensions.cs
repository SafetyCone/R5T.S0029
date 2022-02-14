using System;
using System.Collections.Generic;

using Microsoft.CodeAnalysis;

using R5T.S0029.X002;


namespace System.Linq
{
    public static class IDictionaryExtensions
    {
        public static Dictionary<TNode, TTypedSyntaxAnnotation> ToTypedAnnotationsByNode<TNode, TTypedSyntaxAnnotation>(this IDictionary<TNode, SyntaxAnnotation> untypedAnnotationsByNode,
            Func<SyntaxAnnotation, TTypedSyntaxAnnotation> typedSyntaxAnnotationConstructor)
            where TNode : SyntaxNode
            where TTypedSyntaxAnnotation : SyntaxNodeSyntaxAnnotation<TNode>
        {
            var output = untypedAnnotationsByNode
                .Select(xPair => new { xPair.Key, Value = typedSyntaxAnnotationConstructor(xPair.Value) })
                .ToDictionary(
                    x => x.Key,
                    x => x.Value);

            return output;
        }
    }
}
