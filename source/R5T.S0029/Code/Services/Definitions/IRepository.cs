using System;

using R5T.D0101;
using R5T.D0108;
using R5T.D0109;using R5T.T0064;


namespace R5T.S0029
{[ServiceDefinitionMarker]
    public interface IRepository:IServiceDefinition
    {
        public IExtensionMethodBaseExtensionRepository ExtensionMethodBaseExtensionRepository { get; }
        public IExtensionMethodBaseRepository ExtensionMethodBaseRepository { get; }
        public IProjectRepository ProjectRepository { get; }
    }
}
