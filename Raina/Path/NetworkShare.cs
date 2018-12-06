namespace Raina.Path
{
    using System;

    internal class NetworkShare : IVolume
    {
        public NetworkShare(string host, string share)
        {
            this.Host = host;
            this.Share = share;
        }

        public string Host { get; }
        public string Share { get; }
        public string Name => $@"{Host}\\{Share}";
    }
}