using System;

using R5T.D0101;
using R5T.D0108;
using R5T.D0109;using R5T.T0064;


namespace R5T.S0029
{[ServiceImplementationMarker]
    public class Repository : IRepository,IServiceImplementation
    {
        public IExtensionMethodBaseExtensionRepository ExtensionMethodBaseExtensionRepository { get; private set; }
        public IExtensionMethodBaseRepository ExtensionMethodBaseRepository { get; private set; }
        public IProjectRepository ProjectRepository { get; private set; }


        public Repository(
            IExtensionMethodBaseExtensionRepository extensionMethodBaseExtensionRepository,
            IExtensionMethodBaseRepository extensionMethodBaseRepository,
            IProjectRepository projectRepository)
        {
            this.ExtensionMethodBaseExtensionRepository = extensionMethodBaseExtensionRepository;
            this.ExtensionMethodBaseRepository = extensionMethodBaseRepository;
            this.ProjectRepository = projectRepository;
        }
    }
}
