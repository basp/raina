namespace Raina.Path
{
    internal class LogicalDisk : IVolume
    {
        public LogicalDisk(char drive)
        {
            this.Drive = drive;
        }

        public char Drive { get; }
        public string Name => $@"{Drive}:";
    }
}