using System;

using R5T.Lombardy;

using R5T.D0078;
using R5T.D0079;
using R5T.D0083;
using R5T.D0101;
using R5T.T0064;


namespace R5T.S0029.Library
{
    [ServiceImplementationMarker]
    public class CompilationUnitContextProvider : ICompilationUnitContextProvider, IServiceImplementation
    {
        public IProjectRepository ProjectRepository { get; }
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; }
        public IVisualStudioProjectFileOperator VisualStudioProjectFileOperator { get; }
        public IVisualStudioProjectFileReferencesProvider VisualStudioProjectFileReferencesProvider { get; }
        public IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; }


        public CompilationUnitContextProvider(
            IProjectRepository projectRepository,
            IStringlyTypedPathOperator stringlyTypedPathOperator,
            IVisualStudioProjectFileOperator visualStudioProjectFileOperator,
            IVisualStudioProjectFileReferencesProvider visualStudioProjectFileReferencesProvider,
            IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator)
        {
            this.ProjectRepository = projectRepository;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
            this.VisualStudioProjectFileOperator = visualStudioProjectFileOperator;
            this.VisualStudioProjectFileReferencesProvider = visualStudioProjectFileReferencesProvider;
            this.VisualStudioSolutionFileOperator = visualStudioSolutionFileOperator;
        }
    }
}
