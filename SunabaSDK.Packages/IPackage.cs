using System.Collections.Generic;
using System.IO;

namespace SunabaSDK.Packages
{
    public interface IPackage : IPackageStreamSource
    {
        FileInfo PackageFile { get; }
        IEnumerable<IPackageEntry> GetEntries();
        IPackageEntry GetEntry(string path);
        byte[] ExtractEntry(IPackageEntry entry);
        Stream OpenStream(IPackageEntry entry);
        IPackageStreamSource GetStreamSource();
    }
}