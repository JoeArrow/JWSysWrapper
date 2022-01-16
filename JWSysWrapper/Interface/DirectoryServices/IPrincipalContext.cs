using System;
using System.DirectoryServices.AccountManagement;

namespace JWSysWrap.Interface.DirectoryServices
{
    public interface IPrincipalContext : IDisposable
    {
        PrincipalContext PrincipalContextInstance { get; }
    }
}
