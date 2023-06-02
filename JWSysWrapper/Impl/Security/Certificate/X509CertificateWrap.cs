
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

using JWWrap.Interface.IO;
using JWWrap.Interface.Security.Certificate;

namespace JWWrap.Impl.Security.Certificate
{
    // ----------------------------------------------------
    /// <summary>
    ///     Wrapper for <see cref="X509Certificate2"/> class.
    /// </summary>
    
    public class X509CertificateWrap : IX509Certificate
    {
        // ------------------------------------------------
        /// <summary>
        ///     Gets an instance of a 
        ///     <see cref="X509Certificate2"/>.
        /// </summary>

        public X509Certificate2 Instance { get; private set; }

        // ------------------------------------------------
        /// <summary>
        ///     The wrapper to a file.
        /// </summary>

        private IFile FileWrap { get; set; }

        // ------------------------------------------------
        /// <summary>
        ///     The wrapper to the path.
        /// </summary>

        private IPath PathWrap { get; set; }

        // ------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the 
        ///     <see cref="X509CertificateWrap"/> class.
        /// </summary>

        public X509CertificateWrap(string fileName)
        {
            Instance = new X509Certificate2(fileName);
        }

        // ------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the 
        ///     <see cref="X509CertificateWrap"/> class.
        /// </summary>

        public X509CertificateWrap(string fileName, string password)
        {
            Instance = new X509Certificate2(fileName, password);
        }

        // ------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the 
        ///     <see cref="X509CertificateWrap"/> class.
        /// </summary>

        public X509CertificateWrap(IFile file, IPath path)
        {
            FileWrap = file;
            PathWrap = path;

            Initialize();
        }

        // ------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the 
        ///     <see cref="X509CertificateWrap"/> class.
        /// </summary>
        /// <param name="file"/>
        /// <param name="path"/>
        /// <param name="rawData">
        ///     Byte array containing the X.509 certificate data
        /// </param>
        /// <param name="password">
        ///     The password required to access the X.509 certificate data.
        /// </param>
        
        public X509CertificateWrap(IFile file, IPath path, byte[] rawData, string password = null)
        {
            FileWrap = file;
            PathWrap = path;

            if (password == null)
            {
                Initialize(rawData);
            }
            else
            {
                Initialize(rawData, password);
            }
        }

        // ------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the 
        ///     <see cref="X509CertificateWrap"/> class.
        /// </summary>
        /// <param name="file"/>
        /// <param name="path"/>
        /// <param name="certificate">
        ///     The certificate.
        /// </param>
       
        public X509CertificateWrap(IFile file, IPath path, X509Certificate certificate)
        {
            FileWrap = file;
            PathWrap = path;

            Initialize(certificate);
        }

        // ------------------------------------------------
        /// <summary>
        ///     Gets a collection of X509Extension objects.
        /// </summary>

        public X509ExtensionCollection Extensions { get => Instance.Extensions; }

        // ------------------------------------------------
        /// <summary>
        ///     Gets a value indicating whether an 
        ///     IPamsCertificate object contains a private key. 
        /// </summary>

        public bool HasPrivateKey { get => Instance.HasPrivateKey; }

        // ------------------------------------------------
        /// <summary>
        ///     Gets the name of the certificate authority 
        ///     that issued the X509v3 certificate.
        /// </summary>

        public string Issuer { get => Instance.Issuer; }

        // ------------------------------------------------
        /// <summary>
        ///     Gets the AsymmetricAlgorithm object that 
        ///     represents the private key associated with 
        ///     a certificate.
        /// </summary>

        public AsymmetricAlgorithm PrivateKey { get => Instance.PrivateKey; }

        // ------------------------------------------------
        /// <summary>
        ///     Gets a PublicKey object associated with a 
        ///     certificate.
        /// </summary>

        public PublicKey PublicKey { get => Instance.PublicKey; }

        // ------------------------------------------------
        /// <summary>
        ///     Gets the subject distinguished name from 
        ///     the certificate.
        /// </summary>

        public string Subject { get => Instance.Subject; }

        // ------------------------------------------------
        /// <summary>
        ///     Gets the SHA1 hash value for the X.509v3 
        ///     certificate.
        /// </summary>
        /// <returns>
        ///     The hexadecimal string representation of 
        ///     the X.509 certificate hash value.
        /// </returns>

        public string GetCertHashString()
        {
            return Instance.GetCertHashString();
        }

        // ------------------------------------------------
        /// <summary>
        ///     Gets the <see cref="X509Certificate2"/> instance.
        /// </summary>
        /// <returns>
        ///     The <see cref="X509Certificate2"/>.
        /// </returns>

        public X509Certificate2 GetCertificate()
        {
            return Instance;
        }

        // ------------------------------------------------
        /// <summary>
        ///     Gets the effective date of this X509v3 certificate.
        /// </summary>
        /// <returns>
        ///     The effective date for this X.509 certificate.
        /// </returns>

        public string GetEffectiveDateString()
        {
            return Instance.GetEffectiveDateString();
        }

        // ------------------------------------------------
        /// <summary>
        ///     Gets the expiration date of this X509v3 certificate.
        /// </summary>
        /// <returns>
        ///     The expiration date for this X.509 certificate.
        /// </returns>

        public string GetExpirationDateString()
        {
            return Instance.GetExpirationDateString();
        }

        // ------------------------------------------------
        /// <summary>
        ///     Gets the key algorithm parameters for the 
        ///     X.509v3 certificate.
        /// </summary>
        /// <returns>
        ///     The key algorithm parameters for the X.509 
        ///     certificate as a hexadecimal string.
        /// </returns>

        public string GetKeyAlgorithmParametersString()
        {
            return Instance.GetKeyAlgorithmParametersString();
        }

        // ------------------------------------------------
        /// <summary>
        ///     Gets the raw data for the entire X.509v3 
        ///     certificate as an array of bytes.
        /// </summary>
        /// <returns>
        ///     Byte array containing the X.509 certificate data
        /// </returns>

        public byte[] GetRawCertData()
        {
            return Instance.GetRawCertData();
        }

        // ------------------------------------------------
        /// <summary>
        ///     Gets the raw data for the entire X.509v3 
        ///     certificate as a hexadecimal string.
        /// </summary>
        /// <returns>
        ///     The X.509 certificate data as a hexadecimal string.
        /// </returns>

        public string GetRawCertDataString()
        {
            return Instance.GetRawCertDataString();
        }

        // ------------------------------------------------
        /// <summary>
        ///     Gets the serial number of the X.509v3 certificate.
        /// </summary>
        /// <returns>
        ///     The serial number of the X.509 certificate 
        ///     as an array of bytes.
        /// </returns>

        public byte[] GetSerialNumber()
        {
            return Instance.GetSerialNumber();
        }

        // ------------------------------------------------
        /// <summary>
        ///     Gets the serial number of the X.509v3 certificate.
        /// </summary>
        /// <returns>
        ///     The serial number of the X.509 certificate 
        ///     as a hexadecimal string.
        /// </returns>

        public string GetSerialNumberString()
        {
            return Instance.GetSerialNumberString();
        }

        // ------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the 
        ///     <see cref="X509CertificateWrap"/> class.
        /// </summary>

        public void Initialize()
        {
            Instance = new X509Certificate2();
        }

        // ------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the 
        ///     <see cref="X509CertificateWrap"/> class.
        /// </summary>
        /// <param name="rawData">
        ///     Byte array containing the X.509 certificate data
        /// </param>

        public void Initialize(byte[] rawData)
        {
            Initialize(rawData, null);
        }

        // ------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the 
        ///     <see cref="X509CertificateWrap"/> class.
        /// </summary>
        /// <param name="rawData">
        ///     Byte array containing the X.509 certificate data
        /// </param>
        /// <param name="password">
        ///     The password required to access the X.509 certificate data.
        /// </param>

        public void Initialize(byte[] rawData, string password)
        {
            var filename = PathWrap.GetTempFileName();

            try
            {
                FileWrap.WriteAllBytes(filename, rawData);

                if (password == null)
                {
                    Initialize(filename);
                }

                Initialize(filename, password);
            }
            finally
            {
                FileWrap.Delete(filename);
            }
        }

        // ------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the 
        ///     <see cref="X509Certificate"/> wrapped class.
        /// </summary>
        /// <param name="fileName">
        ///     the file name of a X.509 certificate data
        /// </param>        

        public void Initialize(string fileName)
        {
            Instance = new X509Certificate2(fileName);
        }

        // ------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the 
        ///     <see cref="X509Certificate"/> wrapped class.
        /// </summary>
        /// <param name="fileName">
        ///     the file name of a X.509 certificate data
        /// </param>
        /// <param name="password">
        ///     The password required to access the X.509 certificate data.
        /// </param>

        public void Initialize(string fileName, string password)
        {
            Instance = new X509Certificate2(fileName, password);
        }

        // ------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the 
        ///     <see cref="X509CertificateWrap"/> class.
        /// </summary>
        /// <param name="certificate">
        ///     The certificate.
        /// </param>

        public void Initialize(X509Certificate certificate)
        {
            Instance = new X509Certificate2(certificate);
        }
    }
}