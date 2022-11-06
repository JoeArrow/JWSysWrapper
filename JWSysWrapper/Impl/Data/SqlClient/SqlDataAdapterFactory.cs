#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Data.SqlClient;

using JWSysWrap.Interface.Data.SqlClient;

namespace JWSysWrap.Impl.Data.SqlClient
{
    // ----------------------------------------------------
    /// <summary>
    ///     SqlDataAdapterFactory Description
    /// </summary>

    public class SqlDataAdapterFactory : ISqlDataAdapterFactory
    {
        public void Dispose() { }
        public ISqlDataAdapter Create() => new SqlDataAdapterWrap();
        public ISqlDataAdapter Create(SqlCommand sqlCommand) => new SqlDataAdapterWrap(sqlCommand);
        public ISqlDataAdapter Create(string selectCommandText, SqlConnection selectConnection) => new SqlDataAdapterWrap(selectCommandText, selectConnection);
        public ISqlDataAdapter Create(string selectCommandText, string selectConnectionString) => new SqlDataAdapterWrap(selectCommandText, selectConnectionString);
    }
}
