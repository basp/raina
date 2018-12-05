namespace Raina
{
    using System;
    using System.Threading.Tasks;

    public class Analyzer
    {
        private readonly IAssemblyProvider provider;

        public Analyzer(IAssemblyProvider provider)
        {
            this.provider = provider;
        }

        public IAnalysisResult Analyze()
        {
            throw new NotImplementedException();
        }
    }
}