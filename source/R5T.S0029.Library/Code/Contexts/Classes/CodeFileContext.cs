using System;


namespace R5T.S0029.Library
{
    public class CodeFileContext : ICodeFileContext
    {
        public string CodeFilePath { get; set; }

        public IProjectFileContext ProjectFileContext { get; set; }
    }
}
