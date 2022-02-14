using System;

using R5T.T0036;
using R5T.T0040;
using R5T.T0044;
using R5T.T0045;
using R5T.T0113;


namespace R5T.S0029.Library
{
    public static class Instances
    {
        public static ICompilationUnitOperator CompilationUnitOperator { get; } = T0045.CompilationUnitOperator.Instance;
        public static IFileSystemOperator FileSystemOperator { get; } = T0044.FileSystemOperator.Instance;
        public static IIndentation Indentation { get; } = T0036.Indentation.Instance;
        public static IProjectOperator ProjectOperator { get; } = T0113.ProjectOperator.Instance;
        public static IProjectPathsOperator ProjectPathsOperator { get; } = T0040.ProjectPathsOperator.Instance;
        public static ISolutionOperator SolutionOperator { get; } = T0113.SolutionOperator.Instance;
    }
}
