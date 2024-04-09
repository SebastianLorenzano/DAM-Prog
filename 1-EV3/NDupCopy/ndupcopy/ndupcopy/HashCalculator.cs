using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ndupcopy
{
    public class HashCalculator
    {

        public static string? GetHash(string path)
        {
            const int BUFFER_SIZE = 2048;

            try
            {
                using (FileStream stream = File.OpenRead(path))
                {
                    SHA256 sha256 = SHA256.Create();
                    byte[] buffer = new byte[BUFFER_SIZE];
                    int bytesRead;

                    while ((bytesRead = stream.Read(buffer, 0, BUFFER_SIZE)) > 0)
                        sha256.TransformBlock(buffer, 0, bytesRead, null, 0);

                    sha256.TransformFinalBlock(buffer, 0, 0);

                    return BitConverter.ToString(sha256.Hash).Replace("-", "").ToLowerInvariant();
                }
            }


            catch (IOException ex)
            {
                Console.WriteLine("Error reading the file: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Unauthorized access to the file: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return null;
        }
    }
}
