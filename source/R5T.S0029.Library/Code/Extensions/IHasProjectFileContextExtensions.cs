using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace R5T.S0029.Library
{
    public static class IHasProjectFileContextExtensions
    {
        public static async Task EnsureHasProjectReferences(this IHasProjectFileContext hasProjectFileContext,
            IEnumerable<string> projectIdentityStrings)
        {
            await AsyncAwaitHelper.IfNullThenCompletedTask(
                hasProjectFileContext.ProjectFileContext?.EnsureHasProjectReferences(
                    projectIdentityStrings));
        }

        public static async Task EnsureHasProjectReference(this IHasProjectFileContext hasProjectFileContext,
            string projectIdentityString)
        {
            await AsyncAwaitHelper.IfNullThenCompletedTask(
                hasProjectFileContext.ProjectFileContext?.EnsureHasProjectReference(
                    projectIdentityString));
        }
    }
} 
