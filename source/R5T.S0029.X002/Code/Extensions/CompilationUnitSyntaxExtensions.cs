using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.S0029.X002
{
    public static partial class CompilationUnitSyntaxExtensions
    {
        public static CompilationUnitSyntax GetUsingsAnnotated(this CompilationUnitSyntax compilationUnit,
            out UsingDirectiveAnnotation[] usingDirectiveAnnotations)
        {
            var usingDirectives = compilationUnit.GetUsings();

            var outputCompilationUnit = compilationUnit.AnnotateNodes_Typed(
                usingDirectives,
                UsingDirectiveAnnotation.From,
                out var annotationsByInputNode);

            usingDirectiveAnnotations = annotationsByInputNode.Values.ToArray();

            return outputCompilationUnit;
        }
    }
}