namespace Raina.Path
{
    using System.IO;

    internal class DriveLetter : IDriveLetter
    {
        public DriveInfo DriveInfo => throw new System.NotImplementedException();

        public char Letter => throw new System.NotImplementedException();
    }
}