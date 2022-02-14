using System;


namespace R5T.S0029.Library
{
    public interface IHasProjectFileContext
    {
        /// <summary>
        /// May be null if the code file context was created independent of a project.
        /// Extensions should check the the instance has a project file context, and if not, do nothing.
        /// </summary>
        IProjectFileContext ProjectFileContext { get; }
    }
}
