namespace Raina
{
    using System;
    using Raina.Model;
    
    public class CodeBase : ICodeBase
    {
        public ICodeBaseView Application => throw new NotImplementedException();

        public ICodeBaseView ThirdParty => throw new NotImplementedException();
    }
}