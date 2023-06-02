namespace JWWrap.Interface.Security.Certificate
{
    using System.Collections;
    using System.Security.Cryptography.X509Certificates;

    /// <summary>
    /// Interface wrapping a X509Certificate2Collection.
    /// </summary>
    public interface IX509Certificate2Collection : IEnumerable
    {
        int Count { get; }

        IX509Certificate2 this[int index] { get; }

        /// <summary>
        /// Adds a certificate to an X.509 certificate store.
        /// </summary>
        /// <param name="certificate">
        /// The IPamsCertificate to add to the current X509CertificateCollection. 
        /// </param>
        /// <returns>
        /// The index into the current X509CertificateCollection at which the new IPamsCertificate was inserted.
        /// </returns>

        int Add(IX509Certificate2 certificate);

        IX509Certificate2Collection Find(X509FindType findType, object findValue, bool validOnly);

        /// <summary>
        /// Initializes a new instance of the <see cref="X509Certificate2Collection"/> class.
        /// </summary>
        /// <param name="collection">
        /// The collection of certificates.
        /// </param>

        void Initialize(X509Certificate2Collection collection);
    }
}