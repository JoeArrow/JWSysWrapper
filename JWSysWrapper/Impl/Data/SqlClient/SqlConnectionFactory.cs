#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using JWSysWrap.Interface.Data;
using JWSysWrap.Interface.Data.SqlClient;

namespace JWSysWrap.Impl.Data.SqlClient
{
    // ----------------------------------------------------
    /// <summary>
    ///     SqlConnectionFactory Description
    /// </summary>

    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        public ISqlConnection Create() => new SqlConnectionWrap();
        public ISqlConnection Create(SqlConnection connection) => new SqlConnectionWrap(connection);
        public ISqlConnection Create(string connectionString) => new SqlConnectionWrap(connectionString);

        public void Dispose() { /* Nothing to Dispose of */ }
    }
}
