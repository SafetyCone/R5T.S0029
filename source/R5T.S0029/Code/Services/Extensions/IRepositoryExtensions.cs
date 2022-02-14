using System;
using System.Threading.Tasks;

using R5T.Magyar;

using R5T.T0097;
using R5T.T0100;


namespace R5T.S0029
{
    public static class IRepositoryExtensions
    {
        public static async Task<ExtensionMethodBase> GetExtensionMethodBaseForExtensionMethodBaseExtension(this IRepository repository,
            Guid extensionMethodBaseExtensionIdentity)
        {
            var hasExtensionMethodBase = await repository.HasExtensionMethodBaseForExtensionMethodBaseExtension(
                extensionMethodBaseExtensionIdentity);

            if(!hasExtensionMethodBase)
            {
                throw new Exception($"No extension method base found for extension method base extension identity '{extensionMethodBaseExtensionIdentity}'");
            }

            var output = hasExtensionMethodBase.Result;
            return output;
        }

        public static async Task<WasFound<ExtensionMethodBase>> HasExtensionMethodBaseForExtensionMethodBaseExtension(this IRepository repository,
            Guid extensionMethodBaseExtensionIdentity)
        {
            var hasExtensionMethodBaseIdentity = await repository.ExtensionMethodBaseExtensionRepository.HasExtensionMethodBaseIdentityForExtensionMethodBaseExtension(
                extensionMethodBaseExtensionIdentity);

            if(!hasExtensionMethodBaseIdentity)
            {
                return WasFound.NotFound<ExtensionMethodBase>();
            }

            var hasExtensionMethodBase = await repository.ExtensionMethodBaseRepository.HasExtensionMethodBase(hasExtensionMethodBaseIdentity.Result);
            return hasExtensionMethodBase;
        }

        public static async Task<Project> GetProjectForExtensionMethodBaseExtension(this IRepository repository,
            Guid extensionMethodBaseExtensionIdentity)
        {
            var hasProject = await repository.HasProjectForExtensionMethodBaseExtension(
                extensionMethodBaseExtensionIdentity);

            if(!hasProject)
            {
                throw new Exception($"No project found for extension method base extension identity '{extensionMethodBaseExtensionIdentity}'.");
            }

            var output = hasProject.Result;
            return output;
        }

        public static async Task<WasFound<Project>> HasProjectForExtensionMethodBaseExtension(this IRepository repository,
            Guid extensionMethodBaseExtensionIdentity)
        {
            var hasProjectIdentity = await repository.ExtensionMethodBaseExtensionRepository.HasProjectIdentityForExtensionMethodBaseExtension(
                extensionMethodBaseExtensionIdentity);

            if (!hasProjectIdentity)
            {
                return WasFound.NotFound<Project>();
            }

            var hasProject = await repository.ProjectRepository.HasProject(hasProjectIdentity.Result);
            return hasProject;
        }
    }
}
