namespace Raina.Model
{
    using System;
    using System.Collections.Generic;

    public interface ICodeBase
    {
        ICodeBaseView Application { get; }

        ICodeBaseView ThirdParty { get; }
    }
}