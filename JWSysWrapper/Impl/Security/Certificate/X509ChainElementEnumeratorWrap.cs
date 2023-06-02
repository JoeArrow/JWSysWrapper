
using System.Collections;
using System.Security.Cryptography.X509Certificates;

using JWWrap.Interface.Security.Certificate;

namespace JWWrap.Impl.Security.Certificate
{
    /// ---------------------------------------------------
    /// <summary>
    ///     Wrapper for <see cref="X509ChainElementEnumerator"/>.
    /// </summary>
    
    public class X509ChainElementEnumeratorWrap : IX509ChainElementEnumerator,
                                                  IEnumerator
    {
        /// -----------------------------------------------
        /// <summary>
        ///     The chain elements.
        /// </summary>
        
        private readonly IX509ChainElementCollection chainElements;

        /// -----------------------------------------------
        /// <summary>
        ///     The current value of the enumerator.
        /// </summary>

        private int current;

        /// -----------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the 
        ///     <see cref="X509ChainElementEnumeratorWrap"/> 
        ///     class.
        /// </summary>
        /// <param name="chainElements">
        ///     The chain elements.
        /// </param>
        
        internal X509ChainElementEnumeratorWrap(IX509ChainElementCollection chainElements)
        {
            this.chainElements = chainElements;
            this.current = -1;
        }

        /// -----------------------------------------------
        /// <summary>
        ///     Gets the current <see cref="IX509ChainElement"/>.
        /// </summary>
        
        public IX509ChainElement Current
        {
            get
            {
                return this.chainElements[this.current];
            }
        }

        /// -----------------------------------------------
        /// <summary>
        ///     Gets the current element in the collection.
        /// </summary>
        /// <returns>
        ///     The current element in the collection.
        /// </returns>
        
        object IEnumerator.Current
        {
            get
            {
                return this.chainElements[this.current];
            }
        }

        /// -----------------------------------------------
        /// <summary>
        ///     Advances the enumerator to the next element 
        ///     of the collection.
        /// </summary>
        /// <returns>
        ///     true if the enumerator was successfully advanced to the next element; 
        ///     false if the enumerator has passed the end of the collection.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">
        ///     The collection was modified after the enumerator was created. 
        /// </exception>
        
        public bool MoveNext()
        {
            if (this.current == this.chainElements.Count - 1)
            {
                return false;
            }

            ++this.current;
            return true;
        }

        /// -----------------------------------------------
        /// <summary>
        ///     Sets the enumerator to its initial position, 
        ///     which is before the first element in the collection.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">
        ///     The collection was modified after the enumerator was created. 
        /// </exception>

        public void Reset()
        {
            this.current = -1;
        }
    }
}