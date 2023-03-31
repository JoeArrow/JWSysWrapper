using System.Collections;

namespace JWWrap.Interface.ActiveDirectory
{
    /// <summary>
    /// 
    /// </summary>
    public interface IResultPropertyCollection : ICollection
    {
        /// <summary>
        /// Gets the names of the properties in this collection.
        /// </summary>
        ICollection PropertyNames { get; }

        /// <summary>
        /// Gets the values of the properties in this collection.
        /// </summary>
        ICollection Values { get; }

        /// <summary>
        /// Determines whether the property that has the specified name belongs to this
        /// collection.
        /// </summary>
        /// <param name="name">
        /// The name of the property to get.
        /// </param>
        IResultPropertyValueCollection this[string name] { get; }

        /// <summary>
        /// Determines whether the property that has the specified name belongs to this
        /// collection.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property to find.
        /// </param>
        /// <returns>
        /// The return value is true if the specified property belongs to this collection;
        /// otherwise, false.
        /// </returns>
        bool Contains(string propertyName);
    }
}