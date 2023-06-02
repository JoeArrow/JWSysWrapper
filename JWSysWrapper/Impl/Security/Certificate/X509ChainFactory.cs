
using JWWrap.Interface.Security.Certificate;

namespace JWWrap.Impl.Security.Certificate
{
    /// ---------------------------------------------------
    /// <summary>
    ///     This class wraps a X509Chain in order to be mock-able.
    /// </summary>
   
    public class X509ChainFactory : IX509ChainFactory
    {
        /// -----------------------------------------------
        /// <summary>
        ///     Wraps the X509Chain creation method.
        /// </summary>
        /// <returns>
        ///     The <see cref="IX509Chain"/>.
        /// </returns>
        
        public IX509Chain Create() => new X509ChainWrap();
    }
}