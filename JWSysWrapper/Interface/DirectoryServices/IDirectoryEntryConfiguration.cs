#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.DirectoryServices;

namespace JWWrap.Interface.DirectoryServices
{
    public interface IDirectoryEntryConfiguration
    {
        ReferralChasingOption Referral { get; set; }
        SecurityMasks SecurityMasks { get; set; }
        int PageSize { get; set; }
        int PasswordPort { get; set; }
        PasswordEncodingMethod PasswordEncoding { get; set; }

        string GetCurrentServerName();
        bool IsMutuallyAuthenticated();
        void SetUserNameQueryQuota(string accountName);
    }
}
