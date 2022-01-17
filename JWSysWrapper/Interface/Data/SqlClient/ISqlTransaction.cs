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

namespace JWSysWrap.Interface.Data.SqlClient
{
    public interface ISqlTransaction : IDisposable
    {
        SqlTransaction Instance { get; }

        SqlConnection Connection { get; }
        IsolationLevel IsolationLevel { get; }
        void Commit();
        void Rollback();
        void Rollback(string transactionName);
        void Save(string savePointName);
        void Dispose(bool disposing);
    }
}
