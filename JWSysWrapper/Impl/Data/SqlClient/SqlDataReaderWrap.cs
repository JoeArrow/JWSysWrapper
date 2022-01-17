#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using JWSysWrap.Interface.Data.SqlClient;

namespace JWSysWrap.Impl.Data.SqlClient
{
    // ----------------------------------------------------
    /// <summary>
    ///     SqlDataReaderWrap Description
    /// </summary>

    public class SqlDataReaderWrap : DataReaderWrap, ISqlDataReader
    {
        new public IDataReader Instance { get; private set; }

        public SqlDataReaderWrap(IDataReader dataReader)
            : base(dataReader)
        {
            Initialize(dataReader);
        }

        public void Initialize(IDataReader dataReader) { Instance = dataReader; }
        object ISqlDataReader.this[int i] { get { return Instance[i]; } }
        object ISqlDataReader.this[string name] { get { return Instance[name]; } }
    }
}
