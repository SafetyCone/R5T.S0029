using System;


namespace R5T.S0029.Library
{
    public interface ICodeFileContext : IHasProjectFileContext
    {
        string CodeFilePath { get; }
    }
}
