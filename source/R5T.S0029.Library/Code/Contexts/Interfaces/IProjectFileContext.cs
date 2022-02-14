using System;

using R5T.D0078;
using R5T.D0079;
using R5T.D0083;
using R5T.D0101;


namespace R5T.S0029.Library
{
    public interface IProjectFileContext
    {
        string[] SolutionFilePaths { get; }
        string ProjectFilePath { get; }

        IProjectRepository ProjectRepository { get; }
        IVisualStudioProjectFileOperator VisualStudioProjectFileOperator { get; }
        IVisualStudioProjectFileReferencesProvider VisualStudioProjectFileReferencesProvider { get; }
        IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; }
    }
}
