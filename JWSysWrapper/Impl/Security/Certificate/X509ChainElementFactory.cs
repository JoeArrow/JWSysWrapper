
using System.Security.Cryptography.X509Certificates;

using JWWrap.Interface.IO;
using JWWrap.Interface.Security.Certificate;

namespace JWWrap.Impl.Security.Certificate
{
    /// ---------------------------------------------------
    /// <summary>
    ///     This class wraps a X509ChainElement in order to 
    ///     be mock-able.
    /// </summary>

    public class X509ChainElementFactory : IX509ChainElementFactory
    {
        private readonly IFile file;

        private readonly IPath path;

        /// -----------------------------------------------
        /// <summary/>
        /// <param name="file"/>
        /// <param name="path"/>
       
        public X509ChainElementFactory(IFile file, IPath path)
        {
            this.file = file;
            this.path = path;
        }

        /// -----------------------------------------------
        /// <summary>
        ///     Wraps the X509ChainElement creation method.
        /// </summary>
        /// <returns>
        ///     The <see cref="IX509ChainElement"/>.
        /// </returns>
       
        public IX509ChainElement Create()
        {
            return new X509ChainElementWrap();
        }

        /// -----------------------------------------------
        /// <summary>
        ///     Wraps the X509ChainElement creation method.
        /// </summary>
        /// <param name="element">
        ///     The X.509v3 chain element.
        /// </param>
        /// <returns>
        ///     The <see cref="IX509ChainElement"/>.
        /// </returns>
        
        public IX509ChainElement Create(X509ChainElement element)
        {
            return new X509ChainElementWrap(new X509CertificateWrap(file, path, element.Certificate), element.ChainElementStatus);
        }
    }
}