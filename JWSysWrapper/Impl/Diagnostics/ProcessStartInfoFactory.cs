#region © 2021 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Diagnostics;
using JWWrap.Interface.Diagnostics;

namespace JWWrap.Impl.Diagnostics
{
    // ----------------------------------------------------
    /// <summary>
    ///     ProcessStartInfoFactory Description
    /// </summary>

    public class ProcessStartInfoFactory : IProcessStartInfoFactory
    {
        public IProcessStartInfo Create() => new ProcessStartInfoWrap();
        public IProcessStartInfo Create(string fileName) => new ProcessStartInfoWrap(fileName);
        public IProcessStartInfo Create(ProcessStartInfo processStartInfo) => new ProcessStartInfoWrap(processStartInfo);
        public IProcessStartInfo Create(string fileName, string arguments) => new ProcessStartInfoWrap(fileName, arguments);
        public IProcessStartInfo Create(IProcessStartInfo processStartInfo) => new ProcessStartInfoWrap(processStartInfo.Instance);
    }
}
