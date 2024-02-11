#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Data;
using System.Data.SqlClient;

namespace JWWrap.Interface.Data.SqlClient
{
    public interface ISqlCommand : IWrapper<SqlCommand>, IDisposable
    {
        ISqlParameterCollection Parameters { get; }

        // ------------------------------------------------

        CommandType CommandType { set; get; }

        // ------------------------------------------------

        int CommandTimeout { set; get; }

        // ------------------------------------------------

        ISqlTransaction Transaction { set; get; }

        // ------------------------------------------------

        ISqlConnection Connection { set; get; }

        // ------------------------------------------------

        string CommandText { set; get; }

        // ------------------------------------------------
        /// <summary>
        ///     Sends the CommandText to the Connection and 
        ///     builds a SqlDataReader.
        /// </summary>
        /// <returns>A ISqlDataReaderWrap object. </returns>

        ISqlDataReader ExecuteReader();

        int ExecuteNonQuery();

        // ------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the 
        ///     SqlCommandWrap class.
        /// </summary>

        void Initialize();

        // ------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the 
        ///     SqlCommandWrap class.
        /// </summary>
        /// <param name="command">SqlCommand object.</param>

        void Initialize(SqlCommand command);

        // ------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the 
        ///     SqlCommandWrap class with the text of the 
        ///     query.
        /// </summary>
        /// <param name="cmdText">The text of the query.</param>

        void Initialize(string cmdText);

        // ------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the SqlCommandWrap 
        ///     class with the text of the query and a ISqlConnectionWrap.
        /// </summary>
        /// <param name="cmdText">The text of the query.</param>
        /// <param name="connection">
        ///     A ISqlConnectionWrap that represents the connection 
        ///     to an instance of SQL Server.
        /// </param>

        void Initialize(string cmdText, ISqlConnection connection);
    }
}
