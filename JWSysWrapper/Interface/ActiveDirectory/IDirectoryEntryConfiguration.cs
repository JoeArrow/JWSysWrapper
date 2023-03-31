
using System.DirectoryServices;

namespace JWSysWrap.Interface.ActiveDirectory
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
