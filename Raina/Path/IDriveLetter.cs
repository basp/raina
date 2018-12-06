namespace Raina.Path
{
    using System.IO;

    public interface IDriveLetter
    {
        DriveInfo DriveInfo { get; }
    
        char Letter { get; }
    }    
}