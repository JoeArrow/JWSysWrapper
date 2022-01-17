#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Data;

namespace JWSysWrap.Interface.Data.SqlClient
{
    public interface ISqlDataReader : IDataReader, IDisposable
    {
        IDataReader Instance { get; }

        void Initialize(IDataReader dataReader);

        new bool IsClosed { get; }
        new object this[int i] { get; }
        new object this[string name] { get; }
        new void Close();
        new bool Read();
    }
}
