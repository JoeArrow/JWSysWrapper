#region © 2020 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.DirectoryServices;
using JWSysWrap.Interface.ActiveDirectory;

namespace JWSysWrap.Impl.ActiveDirectory
{
    // ----------------------------------------------------
    /// <summary>
    ///     DirectoryEntryConfiguration Description
    /// </summary>

    public class DirectoryEntryConfigurationWrap : IDirectoryEntryConfiguration
    {
        private readonly DirectoryEntryConfiguration Instance;

        // ------------------------------------------------

        public DirectoryEntryConfigurationWrap(DirectoryEntryConfiguration instance) { Instance = instance; }

        // ------------------------------------------------

        public ReferralChasingOption Referral { set => Instance.Referral = value; get => Instance.Referral; }
        public SecurityMasks SecurityMasks { set => Instance.SecurityMasks = value; get => Instance.SecurityMasks; }        
        public int PageSize { set => Instance.PageSize = value; get => Instance.PageSize; }        
        public int PasswordPort { set => Instance.PasswordPort = value; get => Instance.PasswordPort; }        
        public PasswordEncodingMethod PasswordEncoding { set => Instance.PasswordEncoding = value; get => Instance.PasswordEncoding; }

        public string GetCurrentServerName() { return Instance.GetCurrentServerName(); }
        public bool IsMutuallyAuthenticated() { return Instance.IsMutuallyAuthenticated(); }
        public void SetUserNameQueryQuota(string accountName) { Instance.SetUserNameQueryQuota(accountName); }
    }
}
