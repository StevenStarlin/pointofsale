using Org.BouncyCastle.Crypto.Digests;
using System.Text;

namespace PointOfSaleAPI.Utilities
{
    public class AuthenticationToken : IDisposable
    {
        private int keyBitLength => 512;
        private string passwordKey;

        public AuthenticationToken(string passKey)
        {
            passwordKey = passKey;
        }

        public string BuildToken()
        {
            var hashedKeyBytes = new byte[64];
            var hashAlgorithm = new Sha3Digest(keyBitLength);
            var passwordKeyBytes = Encoding.ASCII.GetBytes(passwordKey);

            hashAlgorithm.BlockUpdate(passwordKeyBytes, 0, passwordKeyBytes.Length);
            hashAlgorithm.DoFinal(hashedKeyBytes, 0);

            return BitConverter
                .ToString(hashedKeyBytes)
                .Replace("-", "")
                .ToLowerInvariant();
        }

        public void Dispose()
        {
            passwordKey = string.Empty;
        }
    }
}
