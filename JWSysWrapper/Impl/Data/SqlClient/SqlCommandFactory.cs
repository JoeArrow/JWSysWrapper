﻿#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Data.SqlClient;

using JWWrap.Interface.Data.SqlClient;

namespace JWWrap.Impl.Data.SqlClient
{
    // ----------------------------------------------------
    /// <summary>
    ///     SqlCommandFactory Description
    /// </summary>

    public class SqlCommandFactory : ISqlCommandFactory
    {
        public ISqlCommand Create() => new SqlCommandWrap();
        public void Dispose() { /* Nothing to dispose of */ }
        public ISqlCommand Create(string cmdText) => new SqlCommandWrap(cmdText);
        public ISqlCommand Create(SqlCommand command) => new SqlCommandWrap(command);
        public ISqlCommand Create(string cmdText, ISqlConnection connection) => new SqlCommandWrap(cmdText, connection);
    }
}
