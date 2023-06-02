
using System.IO;

using JWWrap.Interface.Security.Certificate;

namespace JWWrap.Impl.Security.Certificate
{
    // ----------------------------------------------------
    /// <summary>
    ///     Factory Creating a X509Certificate to avoid bugg 
    ///     in X509Certificate that does not delete tmp files
    /// </summary>
    
    public class X509CertificateFactory : IX509CertificateFactory
    {
        // ------------------------------------------------
        /// <summary>
        ///     Creating an X509Certificate from a byte array
        /// </summary>
        /// <param name="certificateAsBytes">
        ///     The certificate as bytes.
        /// </param>
        /// <param name="password">
        ///     The password needed to access private key. 
        ///     Can be null if the certificate specified as 
        ///     bytes does not require password decryption.
        /// </param>
        /// <returns>
        ///     X509Certificate of the given byte Array
        /// </returns>
        
        public IX509Certificate Create(byte[] certificateAsBytes, string password = null)
        {
            var filename = Path.GetTempFileName();

            try
            {
                File.WriteAllBytes(filename, certificateAsBytes);

                if (password == null)
                {
                    return new X509CertificateWrap(filename);
                }

                return new X509CertificateWrap(filename, password);
            }
            finally
            {
                File.Delete(filename);
            }
        }
    }
}