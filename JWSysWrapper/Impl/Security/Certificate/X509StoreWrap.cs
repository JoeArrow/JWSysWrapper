namespace JWWrap.Impl.Security.Certificate
{
    using System.Security.Cryptography.X509Certificates;

    using JWWrap.Interface.Security.Certificate;

    /// <summary>
    /// Wrapper for <see cref="X509Store"/>.
    /// </summary>
    public class X509StoreWrap : IX509Store
    {
        // ------------------------------------------------
        /// <summary>
        ///     Gets an instance of a <see cref="X509Store"/>.
        /// </summary>
        
        public X509Store Instance { get; private set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="X509StoreWrap"/> class.
        /// </summary>
        /// <param name="storeLocation">
        ///     The store location.
        /// </param>
        
        public X509StoreWrap(StoreLocation storeLocation) { Initialize(storeLocation); }
        
        public X509StoreWrap(IX509Store wrap) { Initialize(wrap); }

        public X509StoreWrap(StoreName storeName, StoreLocation storeLocation) { Initialize(storeName, storeLocation); }

        /// <summary>
        ///     Gets a collection of certificates.
        /// </summary>

        public IX509Certificate2Collection Certificates
        {
            get
            {
                return new X509Certificate2CollectionFactory().Create(Instance.Certificates);
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="X509Store"/> class.
        /// </summary>
        /// <param name="storeLocation">
        ///     One of the enumeration values that specifies the location of the X.509 certificate store. 
        /// </param>
        
        public void Initialize(StoreLocation storeLocation)
        {
            Instance = new X509Store(storeLocation);
        }

        public void Initialize(IX509Store wrap)
        {
            Instance = ((X509StoreWrap)wrap).Instance;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="X509Store"/> class.
        /// </summary>
        /// <param name="storeLocation">
        ///     One of the enumeration values that specifies the location of the X.509 certificate store. 
        /// </param>
        /// <param name="storeName"></param>

        public void Initialize(StoreName storeName, StoreLocation storeLocation)
        {
            Instance = new X509Store(storeName, storeLocation);
        }

        /// <summary>
        /// Opens an X.509 certificate store or creates a new store, depending on OpenFlags flag settings.
        /// </summary>
        /// <param name="flags">
        /// A bitwise combination of enumeration values that specifies the way to open the X.509 certificate store. 
        /// </param>
        
        public void Open(OpenFlags flags)
        {
            Instance.Open(flags);
        }

        // ------------------------------------------------

        public void Close() { Instance.Close(); }
    }
}