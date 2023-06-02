namespace JWWrap.Impl.Security.Certificate
{
    using System.Collections;
    using System.Security.Cryptography.X509Certificates;

    using JWWrap.Interface.Security.Certificate;

    // ----------------------------------------------------
    /// <summary>
    ///     Wrapper for <see cref="X509Certificate2Collection"/>.
    /// </summary>

    public class X509Certificate2CollectionWrap : IX509Certificate2Collection
    {
        private X509Certificate2Collection Instance;

        // ------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the 
        ///     <see cref="X509Certificate2CollectionWrap"/> class.
        /// </summary>

        public X509Certificate2CollectionWrap()
        {
            Instance = new X509Certificate2Collection();
        }

        // ------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the 
        ///     <see cref="X509Certificate2CollectionWrap"/> class.
        /// </summary>
        /// <param name="collection">
        ///     The collection of certificates.
        /// </param>

        public X509Certificate2CollectionWrap(X509Certificate2Collection collection)
        {
            Initialize(collection);
        }

        // ------------------------------------------------

        public int Count => Instance.Count;

        // ------------------------------------------------

        public IX509Certificate2 this[int index] 
        {
            get 
            {
                return new X509Certificate2Wrap(Instance[index]);
            }
        }

        // ------------------------------------------------
        /// <summary>
        ///     Adds a certificate to an X.509 certificate 
        ///     store.
        /// </summary>
        /// <param name="certificate">
        ///     The certificate to add.
        /// </param>
        /// <returns>
        ///     The <see cref="int"/>.
        /// </returns>

        public int Add(IX509Certificate2 certificate)
        {
            return Instance.Add(certificate.Instance);
        }

        // ------------------------------------------------

        public IX509Certificate2Collection Find(X509FindType findType, object findValue, bool validOnly)
        {
            return new X509Certificate2CollectionWrap(Instance.Find(findType, findValue, validOnly));
        }

        // ------------------------------------------------

        public IEnumerator GetEnumerator()
        {
            return Instance.GetEnumerator();
        }

        // ------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the 
        ///     <see cref="X509Certificate2Collection"/> class.
        /// </summary>
        /// <param name="collection">
        ///     The collection of certificates.
        /// </param>

        public void Initialize(X509Certificate2Collection collection)
        {
            Instance = Instance ?? new X509Certificate2Collection();

            foreach(var certificate in collection)
            {
                Instance.Add(certificate);
            }
        }
    }
}