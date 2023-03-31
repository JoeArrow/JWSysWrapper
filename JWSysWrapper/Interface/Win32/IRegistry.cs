#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using Microsoft.Win32;

namespace JWWrap.Interface.Win32
{
    public interface IRegistry
    {
        RegistryKey CurrentUser { get; }
        RegistryKey LocalMachine { get; }
        RegistryKey ClassesRoot { get; }
        RegistryKey Users { get; }
        RegistryKey PerformanceData { get; }
        RegistryKey CurrentConfig { get; }
        RegistryKey DynData { get; }

        object GetValue(string keyName, string valueName, object defaultValue);
        void SetValue(string keyName, string valueName, object value);
        void SetValue(string keyName, string valueName, object value, RegistryValueKind valueKind);
    }
}
