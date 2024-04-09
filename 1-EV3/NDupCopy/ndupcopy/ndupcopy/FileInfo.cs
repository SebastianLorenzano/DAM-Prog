using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace ndupcopy
{
    public class FileInfo
    {
        public int Hash { get; set; }
        public double Size { get; set; }
        public string? Path { get; set; }
        public bool IsDisabled { get; set; }

        private FileInfo()
        {

        }

        public static FileInfo? Create(int hash, double size, string path, bool is_disabled = false)
        {
            if (path != null)
                return new FileInfo()
                { Hash = hash, Size = size, Path = path, IsDisabled = is_disabled};
            return null;
        }

    }
}
