#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Data;
using System.Data.SqlClient;

using JWSysWrap.Interface.Data.SqlClient;

namespace JWSysWrap.Impl.Data.SqlClient
{
    // ----------------------------------------------------
    /// <summary>
    ///     SqlTransactionWrap Description
    /// </summary>

    public class SqlTransactionWrap : ISqlTransaction
    {
        public SqlTransaction Instance { get; private set; }

        // ------------------------------------------------

        public SqlTransactionWrap(){ }

        public SqlTransactionWrap(SqlTransaction instance) => Initialize(instance);

        // ------------------------------------------------

        public void Initialize(SqlTransaction instance) => Instance = instance;

        // ------------------------------------------------

        public void Commit() => Instance.Commit();
        public void Rollback() => Instance.Rollback();
        public void Dispose(bool disposing) => Instance.Dispose();
        public SqlConnection Connection { get => Instance.Connection; }
        public void Save(string savePointName) => Instance.Save(savePointName);
        public IsolationLevel IsolationLevel { get => Instance.IsolationLevel; }
        public void Rollback(string transactionName) => Instance.Rollback(transactionName);

        public void Dispose()
        {
            if(Instance != null)
            {
                Instance.Dispose();
            }
        }
    }
}
