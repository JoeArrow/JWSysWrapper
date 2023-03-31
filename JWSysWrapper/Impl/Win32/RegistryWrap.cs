#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using JWWrap.Interface.Win32;

using Microsoft.Win32;

namespace JWWrap.Impl.Win32
{
    // ----------------------------------------------------
    /// <summary>
    ///     RegistryWrap Description
    /// </summary>

    public class RegistryWrap : IRegistry
    {
        public RegistryKey CurrentUser => Registry.CurrentUser;

        public RegistryKey LocalMachine => Registry.LocalMachine;

        public RegistryKey ClassesRoot => Registry.ClassesRoot;

        public RegistryKey Users => Registry.Users;

        public RegistryKey PerformanceData => Registry.PerformanceData;

        public RegistryKey CurrentConfig => Registry.CurrentConfig;

        [System.Obsolete]
        public RegistryKey DynData => Registry.DynData;

        public object GetValue(string keyName, string valueName, object defaultValue) => Registry.GetValue(keyName, valueName, defaultValue);

        public void SetValue(string keyName, string valueName, object value) => Registry.SetValue(keyName, valueName,  value);

        public void SetValue(string keyName, string valueName, object value, RegistryValueKind valueKind) => 
            Registry.SetValue(keyName, valueName, value, valueKind);
    }
}
