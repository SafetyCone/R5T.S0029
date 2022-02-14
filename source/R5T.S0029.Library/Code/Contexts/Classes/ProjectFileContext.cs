using System;

using R5T.D0078;
using R5T.D0079;
using R5T.D0083;
using R5T.D0101;


namespace R5T.S0029.Library
{
    public class ProjectFileContext : IProjectFileContext
    {
        public string[] SolutionFilePaths { get; set; }
        public string ProjectFilePath { get; set; }

        public IProjectRepository ProjectRepository { get; set; }
        public IVisualStudioProjectFileOperator VisualStudioProjectFileOperator { get; set; }
        public IVisualStudioProjectFileReferencesProvider VisualStudioProjectFileReferencesProvider { get; set; }
        public IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; set; }
    }
}
