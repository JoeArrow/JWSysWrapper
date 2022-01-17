#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Data;
using System.ComponentModel;
using System.Data.SqlClient;

namespace JWSysWrap.Interface.Data.SqlClient
{
    public interface ISqlConnection : IDisposable
    {
        SqlConnection Instance { get; }

        void Initialize();
        void Initialize(SqlConnection connection);
        void Initialize(string connectionString);
        string ConnectionString { get; set; }
        int ConnectionTimeout { get; }
        string Database { get; }
        [Browsable(true)]
        string DataSource { get; }
        bool FireInfoMessageEventOnUserErrors { get; set; }
        int PacketSize { get; }
        [Browsable(false)]
        string ServerVersion { get; }
        [Browsable(false)]
        ConnectionState State { get; }
        bool StatisticsEnabled { get; set; }
        string WorkstationId { get; }
        void Close();
        void Open();
        ISqlTransaction BeginTransaction();
    }
}
