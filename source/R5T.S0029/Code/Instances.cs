using System;

using R5T.T0039;
using R5T.T0040;
using R5T.T0044;
using R5T.T0055;
using R5T.T0062;
using R5T.T0070;
using R5T.T0098;
using R5T.T0125.T002;


namespace R5T.S0029
{
    public static class Instances
    {
        public static IExtensionMethodBaseFunctionality ExtensionMethodBaseFunctionality { get; } = T0039.ExtensionMethodBaseFunctionality.Instance;
        public static IFileSystemOperator FileSystemOperator { get; } = T0044.FileSystemOperator.Instance;
        public static IGuidOperator GuidOperator { get; } = T0055.GuidOperator.Instance;
        public static IHost Host { get; } = T0070.Host.Instance;
        public static IOperation Operation { get; } = T0098.Operation.Instance;
        public static IProjectPath ProjectPath { get; } = T0040.ProjectPath.Instance;
        public static IProjectPathsOperator ProjectPathsOperator { get; } = T0040.ProjectPathsOperator.Instance;
        public static IServiceAction ServiceAction { get; } = T0062.ServiceAction.Instance;
        public static IUsingDirectiveBlockSortOrder UsingDirectiveBlockSortOrder { get; } = T0125.T002.UsingDirectiveBlockSortOrder.Instance;
    }
}