#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.DirectoryServices;
using System.Runtime.InteropServices;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JWWrap.IntgTests.DirectoryServices
{
    // ----------------------------------------------------
    /// <summary>
    ///     Creates and removes an isolated scratch container in the local AD LDS instance
    /// </summary>

    public sealed class AdLdsScratch : IDisposable
    {
        public const string Server = "localhost:389";

        public const string BaseDn = "CN=Desktop,DC=local";

        // ----------------------------------------------------

        private AdLdsScratch(string name, DirectoryEntry container)
        {
            Name = name;
            Container = container;
        }

        // ----------------------------------------------------

        public string Name { get; }

        public DirectoryEntry Container { get; }

        public string DistinguishedName => "CN=" + Name + "," + BaseDn;

        public string Path => "LDAP://" + Server + "/" + DistinguishedName;

        // ----------------------------------------------------

        public string ChildPath(string relativeDn)
        {
            return "LDAP://" + Server + "/" + relativeDn + "," + DistinguishedName;
        }

        // ----------------------------------------------------

        public static AdLdsScratch Create()
        {
            var name = "JWWrapIntgTests_" + Guid.NewGuid().ToString("N");

            try
            {
                using(var parent = new DirectoryEntry("LDAP://" + Server + "/" + BaseDn, null, null, AuthenticationTypes.Secure))
                {
                    var container = parent.Children.Add("CN=" + name, "container");

                    container.CommitChanges();

                    return new AdLdsScratch(name, container);
                }
            }
            catch(COMException ex)
            {
                throw new AssertInconclusiveException("AD LDS is not available at " + Server + ": " + ex.Message);
            }
        }

        // ----------------------------------------------------

        public void AddGroup(string name, string description = null)
        {
            using(var group = Container.Children.Add("CN=" + name, "group"))
            {
                if(description != null)
                {
                    group.Properties["description"].Value = description;
                }

                group.CommitChanges();
            }
        }

        // ----------------------------------------------------

        public void Dispose()
        {
            try
            {
                Container.DeleteTree();
            }
            catch(COMException)
            {
            }

            Container.Dispose();
        }
    }
}
