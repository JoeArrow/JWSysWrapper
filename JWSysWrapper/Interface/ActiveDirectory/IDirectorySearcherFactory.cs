namespace JWWrap.Interface.ActiveDirectory
{
    /// <summary>
    /// 
    /// </summary>
    
    public interface IDirectorySearcherFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="directoryEntry">
        /// </param>
        /// <param name="pageSize">
        /// </param>
        /// <param name="sizeLimit">
        /// </param>
        /// <returns>
        /// </returns>
        
        IDirectorySearcher Create(IDirectoryEntry directoryEntry, int sizeLimit = 20, int? pageSize = null);
    }
}
