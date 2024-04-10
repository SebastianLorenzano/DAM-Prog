using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace ndupcopy
{
    public class FileInfo
    {
        public string Path { get; set; }
        public double Length { get; set; }
        public int HashL { get; set; }     // Hash Long, comes from getting a long from HashS
        public string HashS { get; set; }   // Hash String
        public bool IsDisabled { get; set; }



        /*
        public static FileInfo? Create(int hash, double size, string path, bool is_disabled = false)
        {
            if (path != null)
                return new FileInfo()
                { Hash = hash, Length = size, Path = path, IsDisabled = is_disabled};
            return null;
        }
        */

    }
}
