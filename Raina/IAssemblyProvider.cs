namespace Raina
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public interface IAssemblyProvider
    {
        IEnumerable<FileInfo> GetFiles();
    }
}