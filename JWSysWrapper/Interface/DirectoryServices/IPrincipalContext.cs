using System;
using System.DirectoryServices.AccountManagement;

namespace JWWrap.Interface.DirectoryServices
{
    public interface IPrincipalContext : IDisposable
    {
        PrincipalContext PrincipalContextInstance { get; }
    }
}
