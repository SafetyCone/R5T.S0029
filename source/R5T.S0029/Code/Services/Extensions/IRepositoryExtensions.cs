using System;
using System.Collections.Generic;
using System.Linq;
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

        public static async Task<ExtensionMethodBase[]> GetExtensionMethodBaseForExtensionMethodBaseExtensions(this IRepository repository,
            IEnumerable<Guid> extensionMethodBaseExtensionIdentities)
        {
            var hasExtensionMethodBase = await repository.HasExtensionMethodBaseForExtensionMethodBaseExtensions(
                extensionMethodBaseExtensionIdentities);

            if (!hasExtensionMethodBase.AnyNotFound())
            {
                throw new Exception("No extension method base found for some extension method base extension identities.");
            }

            var output = hasExtensionMethodBase
                .Select(x => x.Value.Result)
                .ToArray();

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

        public static async Task<Dictionary<Guid, WasFound<ExtensionMethodBase>>> HasExtensionMethodBaseForExtensionMethodBaseExtensions(this IRepository repository,
            IEnumerable<Guid> extensionMethodBaseExtensionIdentities)
        {
            var hasExtensionMethodBaseIdentitiesByExtensionMethodBaseExtensionIdentity = await repository.ExtensionMethodBaseExtensionRepository.HasExtensionMethodBaseIdentitiesForExtensionMethodBaseExtensions(
                extensionMethodBaseExtensionIdentities);

            var notFoundExtensionMethodBasesByExtensionMethodBaseExtensionIdentityPairs = hasExtensionMethodBaseIdentitiesByExtensionMethodBaseExtensionIdentity
                .Where(x => !x.Value.Exists)
                .Select(x => new KeyValuePair<Guid, WasFound<ExtensionMethodBase>>(
                    x.Key,
                    WasFound.NotFound<ExtensionMethodBase>()))
                ;

            var extensionMethodBaseIdentitiesByExtensionMethodBaseExtensionIdentityWhereFound = hasExtensionMethodBaseIdentitiesByExtensionMethodBaseExtensionIdentity
                .Where(x => x.Value.Exists)
                .ToDictionary(
                    x => x.Key,
                    x => x.Value.Result);

            var hasExtensionMethodBasesByExtensionMethodBaseIdentity = await repository.ExtensionMethodBaseRepository.HasExtensionMethodBases(
                extensionMethodBaseIdentitiesByExtensionMethodBaseExtensionIdentityWhereFound.Values);

            var foundExtensionMethodBasesByExtensionMethodBaseExtensionIdentityPairs = extensionMethodBaseIdentitiesByExtensionMethodBaseExtensionIdentityWhereFound
                .Select(x => new KeyValuePair<Guid, WasFound<ExtensionMethodBase>>(
                    x.Key,
                    hasExtensionMethodBasesByExtensionMethodBaseIdentity[x.Value]))
                ;

            var output = notFoundExtensionMethodBasesByExtensionMethodBaseExtensionIdentityPairs
                .Concat(foundExtensionMethodBasesByExtensionMethodBaseExtensionIdentityPairs)
                .ToDictionary(
                    x => x.Key,
                    x => x.Value);

            return output;
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
