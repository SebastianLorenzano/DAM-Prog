using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace ndupcopy
{
    public class FileInfo
    {
        public string Path { get; set; }
        public string ContainerPath { get; set; }
        public double Length { get; set; }
        public int HashL { get; set; }     // Hash Long, comes from getting a long from HashS
        public string HashS { get; set; }   // Hash String
        public bool IsDisabled { get; set; } 
        public string NewPath { get; set; }

    }
}
