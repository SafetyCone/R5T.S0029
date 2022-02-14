using System;
using System.Threading.Tasks;

using R5T.Lombardy;

using R5T.D0078;
using R5T.D0079;
using R5T.D0083;
using R5T.D0101;
using R5T.T0064;


namespace R5T.S0029.Library
{
    [ServiceDefinitionMarker]
    public interface ICompilationUnitContextProvider : IServiceDefinition
    {
        IProjectRepository ProjectRepository { get; }
        IStringlyTypedPathOperator StringlyTypedPathOperator { get; }
        IVisualStudioProjectFileOperator VisualStudioProjectFileOperator { get; }
        IVisualStudioProjectFileReferencesProvider VisualStudioProjectFileReferencesProvider { get; }
        IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; }
    }
}
